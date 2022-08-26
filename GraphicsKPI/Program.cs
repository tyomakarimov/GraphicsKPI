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
            
            var light = new Light(new Vector(120, 120, 70));
            var camera = new Camera(new Point(1800, 10, -18));

            var outputFile = "";
            var inputFile = " ";

            foreach (var arg in args)
            {
                if (arg.StartsWith("--output"))
                {
                    outputFile = arg[9..arg.Length];
                }

                if (arg.StartsWith("--source"))
                {
                    inputFile = arg[9..arg.Length];
                }
            }

            var matrix = new Matrix();
            matrix.Translate(new Vector(10, 10, 10));
            //matrix.RotateX(70);
            matrix.Scale(new Vector(1.2, 1.2, 1.2));

            var tracer = new Tracer(camera, light, screen);

            var sphere1 = new Sphere(new Point(-150, 0, 2), 80, new Color(179, 255, 255));

            // var plane = new Plane(new Point(-180, 100, 10), new Vector(0, 15, 0));
            
            // plane.Transform(matrix);
            
            sphere1.Transform(matrix);
            
            tracer.AddFigureToList(sphere1);
            // tracer.AddFigureToList(plane);

            tracer.Render(colors);

            PpmWriter.WriteToFile(outputFile, colors).Wait();
        }
    }
}
