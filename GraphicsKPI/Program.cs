using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;

namespace GraphicsKPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Point screenCenter = new Point(-15, 15, -5);
            Screen screen = new Screen(screenCenter, 30, 30);

            Sphere sphere = new Sphere(new Point(-15, 16, 2), 9);
            Light light = new Light(new Vector(38, 15, 60));
            //Light light = new Light(new Vector(2, -3, -1));
            Camera camera = new Camera(new Point(20, 10, 15));
            //Triangle triangle = new Triangle(new Point(-10, 5, -2), new Point(-10, 20, -2), new Point(-10, 12, 12));

            Tracer tracer = new Tracer(camera, light, screen);
            double t = 0.0;
            Vector test = (screenCenter - new Point(20, 10, 15)).Normalize();

            Point origin = new Point(20, 10, 15);
            Ray testRay = new Ray(origin, test);
            Console.WriteLine(test);
            sphere.CheckIntersectionWith(testRay, ref t);
            Console.WriteLine(testRay.GetPointByT(t));
            Console.WriteLine(Math.Round(testRay.GetPointByT(t).z, 2));
            //tracer.AddFigureToList(sphere);
            //tracer.AddFigureToList(triangle);
            //tracer.render();

        }
    }
}
