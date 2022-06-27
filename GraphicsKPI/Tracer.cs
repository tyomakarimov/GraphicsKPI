using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using System.Collections.Generic;


namespace GraphicsKPI
{
    internal class Tracer
    {
        private Camera _camera;
        private Light _light;
        private Color _backgroundColor;
        private List<IFigure> _figureList;
        private Screen _screen;

        public Tracer(Camera camera, Light light, Screen screen)
        {
            _camera = camera;
            _light = light;
            _screen = screen;
            _figureList = new List<IFigure>();
            _backgroundColor = new Color(204, 153, 255);
        }

        public void AddFigureToList(IFigure figure)
        {
            _figureList.Add(figure);
        }

        public Color CalcColor(Vector normal)
        {
            var scalarMult = Math.Max(_light.direction.Dot(normal), 0.0);
            var result = (int)Math.Ceiling(255 * scalarMult);
            return new Color(result, result, result);
        }
        
        public void render(Color[,] matrix)
        {
            Point origin = _camera._location;

            if (_figureList.Count == 1)
            {
                ProcessSingleObject(origin, matrix);
            } else if (_figureList.Count > 1)
            {
                ProcessMultipleObjects(origin, matrix);
            } else
            {
                Console.WriteLine("You didn`t add any figures on the scene to render");
                return;
            }
        }

        public void ProcessSingleObject(Point origin, Color[,] matrix)
        {
            IFigure obj = _figureList[0];
            for (int x = 0; x < _screen.Width; x++)
            {
                for (int y = 0; y < _screen.Height; y++)
                {
                    Point dest = _screen.GetPointByScreenCoord(x, y);
                    Vector direction = dest - origin;
                    Ray ray = new Ray(origin, direction);

                    double tval = 0.0;
                    if (obj.CheckIntersectionWith(ray, ref tval))
                    {
                        Point intersectionPoint = ray.GetPointByT(tval);
                        Vector normal = obj.GetNormalAtPoint(intersectionPoint);
                        matrix[x, y] = CalcColor(normal);
                    }
                    else
                    {
                        matrix[x, y] = _backgroundColor;
                    }
                }
            }
        }

        public void ProcessMultipleObjects(Point origin, Color[,] matrix)
        {
            for (int x = 0; x < _screen.Width; x++)
            {
                for (int y = 0; y < _screen.Height; y++)
                {

                    Point dest = _screen.GetPointByScreenCoord(x, y);
                    Vector direction = dest - origin;
                    Ray ray = new Ray(origin, direction);

                    double tval = double.MaxValue;
                    IFigure closestObj = null;

                    for (int i = 0; i < _figureList.Count(); i++)
                    {
                        double temptval = 0.0;
                        if (_figureList[i].CheckIntersectionWith(ray, ref temptval))
                        {
                            if (temptval < tval)
                            {
                                tval = temptval;
                                closestObj = _figureList[i];
                            }
                        }
                    }

                    if (closestObj is not null)
                    {
                        Point intersectionPoint = ray.GetPointByT(tval);
                        Vector normal = closestObj.GetNormalAtPoint(intersectionPoint);
                        matrix[x, y] = CalcColor(normal);
                    } else
                    {
                        matrix[x, y] = _backgroundColor;
                    }

                }
            }
        }

    }
}
