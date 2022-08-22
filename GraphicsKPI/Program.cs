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
            
            var points = new List<Point>();
            var normals = new List<Vector>();
            var triangles = new List<Triangle>();

            var triangleIndexes = new List<List<(int, int)>>();

            ObjReader.ReadFromFile(inputFile, points, normals, triangleIndexes).Wait();
            
            foreach (var indexes in triangleIndexes)
            {
                var (firstVertexIndex, firstVertexNormal) = indexes[0];
                var (secondVertexIndex, secondVertexNormal) = indexes[1];
                var (thirdVertexIndex, thirdVertexNormal) = indexes[2];

                var triangle = new Triangle(points[firstVertexIndex - 1], 
                    points[secondVertexIndex - 1],
                    points[thirdVertexIndex - 1], 
                    normals[firstVertexNormal - 1],
                    normals[secondVertexNormal - 1],
                    normals[thirdVertexNormal - 1]);
                triangles.Add(triangle);
            }
            
            var tracer = new Tracer(camera, light, screen);

            foreach (var triangle in triangles)
            {
                tracer.AddFigureToList(triangle);
            }

            tracer.Render(colors);
            
            PpmWriter.WriteToFile(outputFile, colors).Wait();
        }
    }
}
