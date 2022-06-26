using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;

namespace GraphicsKPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Point screenCenter = new Point(-15, 10, 0);
            Screen screen = new Screen(screenCenter, 30, 30);
            Point[,] pixels = new Point[30, 30];

            Sphere sphere = new Sphere(new Point(-15, 10, 2), 9);
            Light light = new Light(new Vector(12, -12, -6));
            //Light light = new Light(new Vector(2, -3, -1));
            Camera camera = new Camera(new Point(20, 10, 15));
            Triangle triangle = new Triangle(new Point(-10, 0, -2), new Point(-10, 15, -2), new Point(-10, 7, 12));

            Tracer tracer = new Tracer(camera, light, screen);
            //tracer.AddFigureToList(sphere);
            tracer.AddFigureToList(triangle);
            tracer.render();

        }
    }
}
