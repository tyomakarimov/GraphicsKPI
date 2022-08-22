using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;

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
            _backgroundColor = new Color(255, 255, 204);
        }

        public void AddFigureToList(IFigure figure)
        {
            _figureList.Add(figure);
        }

        public void Render(Color[,] colors)
        {
            var origin = _camera._location;

            if (_figureList.Count >= 1)
            {
                ProcessMultipleObjects(origin, colors);
            } else
            {
                Console.WriteLine("At least one figure should be added");
            }
        }

        private void ProcessMultipleObjects(Point origin, Color[,] colors)
        {
            for (var x = 0; x < _screen.Width; x++)
            {
                for (var y = 0; y < _screen.Height; y++)
                {
                    var dest = _screen.GetPointByScreenCoord(x, y);
                    var direction = dest - origin;
                    var ray = new Ray(origin, direction);

                    var tval = double.MaxValue;
                    IFigure closestObj = null;

                    foreach (var figure in _figureList)
                    {
                        var temptval = 0.0;
                        if (figure.CheckIntersectionWith(ray, ref temptval) && temptval < tval)
                        {
                            tval = temptval;
                            closestObj = figure;
                        }
                    }

                    if (closestObj is not null)
                    {
                        colors[x, y] = closestObj.GetColor();
                    } else
                    {
                        colors[x, y] = _backgroundColor;
                    }
                }
            }
        }
    }
}
