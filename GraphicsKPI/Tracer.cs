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
        }

        public void AddFigureToList(IFigure figure)
        {
            _figureList.Add(figure);
        }

        public char CalcCharacter(Vector normal)
        {
            var result = _light.direction.Dot(normal);
            char character;
            if (result > 0.8f)
            {
                character = '#';
            } else if (result > 0.5f)
            {
                character = 'O';
            } else if (result > 0.2f)
            {
                character = '*';
            } else if (result > 0f)
            {
                character = '.';
            } else
            {
                character = ' ';
            };
            return character;
        }
        
        public void render()
        {
            Point origin = _camera._location;
            char[,] charList = new char[_screen.Width, _screen.Height];

            if (_figureList.Count == 1)
            {
                processSingleObject(origin, charList);
            } else if (_figureList.Count > 1)
            {
                processMultipleObjects(origin, charList);
            } else
            {
                Console.WriteLine("You didn`t add any figures on the scene to render");
                return;
            }

            for (int x = 0; x < _screen.Width; x++)
            {
                for (int y = 0; y < _screen.Height; y++)
                {
                    Console.Write(charList[x, y] + " ");
                }
                Console.Write("\n");
            }
        }

        private void processSingleObject(Point origin, char[,] charList)
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
                        charList[x, y] = CalcCharacter(normal);
                    }
                    else
                    {
                        charList[x, y] = '-';
                    }
                }
            }
        }

        private void processMultipleObjects(Point origin, char[,] charList)
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
                        charList[x, y] = CalcCharacter(normal);
                    } else
                    {
                        charList[x, y] = '-';
                    }

                }
            }
        }

    }
}
