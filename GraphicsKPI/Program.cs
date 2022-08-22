using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using GraphicsKPI.Utils;

namespace GraphicsKPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int height = 300;
            const int width = 300;
            
            var screenCenter = new Point(40, 10, 4);
            var screen = new Screen(screenCenter, height, width);
            
            var colors = new Color[height, width];

            var sphere1 = new Sphere(new Point(-150, 0, 2), 80, new Color(179, 255, 255));
            var sphere2 = new Sphere(new Point(30, 100, 10), 30, new Color(153, 255, 204));
            var sphere3 = new Sphere(new Point(-30, -80, 60), 50, new Color(255, 204, 204));
            
            var light = new Light(new Vector(120, 120, 70));
            var camera = new Camera(new Point(1800, 10, -18));

            var tracer = new Tracer(camera, light, screen);

            tracer.AddFigureToList(sphere1);
            tracer.AddFigureToList(sphere2);
            tracer.AddFigureToList(sphere3);

            tracer.Render(colors);
            
            var outputFile = "";

            foreach (var arg in args)
            {
                if (arg.StartsWith("--output"))
                {
                    outputFile = arg[9..arg.Length];
                }
            }
            
            PpmWriter.WriteToFile(outputFile, colors).Wait();
        }
    }
}
