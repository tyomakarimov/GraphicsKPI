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

        public Color CalcColor(Vector normal, IFigure obj)
        {
            var objColor = obj.GetColor();
            var scalarMult = Math.Max(_light.direction.Dot(normal), 0.0);
            var resultR = (int)Math.Ceiling(objColor.r * scalarMult);
            var resultG = (int)Math.Ceiling(objColor.b * scalarMult);
            var resultB = (int)Math.Ceiling(objColor.g * scalarMult);
            return new Color(resultR, resultG, resultB);
        }
        
        public void render(Color[,] matrix)
        {
            Point origin = _camera._location;

            if (_figureList.Count >= 1)
            {
                ProcessMultipleObjects(origin, matrix);
            } else
            {
                Console.WriteLine("You didn`t add any figures on the scene to render");
                return;
            }
            ProcessMultipleObjects(origin, matrix);
        }

        public bool RayHasAnyCross(Ray ray)
        {
            double t = 0.0;
            foreach (IFigure obj in _figureList)
            {
                if (obj.CheckIntersectionWith(ray, ref t))
                {
                    return true;
                }
            }
            return false;
        }

        public Color FindShade(Vector normal, Point intersectionPoint, IFigure closest)
        {
            Point point = intersectionPoint + normal.MultiplyBy(0.001f);
            Ray ray = new Ray(point, _light.direction);

            double scalarMult = Math.Max(_light.direction.Dot(normal), 0.0);
            if (scalarMult > 0.0 && RayHasAnyCross(ray))
            {
                return new Color(0, 0, 0);
            }
            Color objColor = closest.GetColor();
            var resultR = (int)Math.Ceiling(objColor.r * scalarMult);
            var resultG = (int)Math.Ceiling(objColor.b * scalarMult);
            var resultB = (int)Math.Ceiling(objColor.g * scalarMult);
            return new Color(resultR, resultG, resultB);
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

                    if (closestObj is null)
                    {
                        matrix[x, y] = _backgroundColor;
                    } else
                    {
                        Point intersectionPoint = ray.GetPointByT(tval);
                        Vector normal = closestObj.GetNormalAtPoint(intersectionPoint);
                        matrix[x, y] = FindShade(normal, intersectionPoint, closestObj);
                    }

                }
            }
        }

    }
}
