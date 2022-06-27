using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using GraphicsKPI.Utilities;

namespace GraphicsKPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            string sourceFileName = " ";
            string outputFileName = " ";

            foreach (var arg in args)
            {
                if (arg.StartsWith("--source"))
                {
                    sourceFileName = arg.Substring(9);
                }
                else
                {
                    outputFileName = arg.Substring(9);
                }
            }


            Point screenCenter = new Point(-15, 15, 7);
            Screen screen = new Screen(screenCenter, 300, 300);

            Color[,] data = new Color[300, 300];

            Sphere sphere = new Sphere(new Point(-70, 20, 2), 50);
            Light light = new Light(new Vector(38, 15, 60));
            //Light light = new Light(new Vector(2, -3, -1));
            Camera camera = new Camera(new Point(20, 10, 15));
            //Triangle triangle = new Triangle(new Point(-10, 5, -2), new Point(-10, 20, -2), new Point(-10, 12, 12));

            //Tracer tracer = new Tracer(camera, light, screen);
            //tracer.AddFigureToList(sphere);
            //tracer.AddFigureToList(triangle);
            //tracer.render(data);
            //PpmFileWriter.WriteToFile(outputFileName, data).Wait();

            List<Point> vertexes = new List<Point>();
            List<Vector> normals = new List<Vector>();
            List<Triangle> triangles = new List<Triangle>();

            List<List<(int, int)>> triangleIndexes = new List<List<(int, int)>>();

            ObjFileParser.ParseObjFile(sourceFileName, vertexes, normals, triangleIndexes).Wait();

            Console.WriteLine(triangleIndexes.Count());

        }
    }
}
