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

            Color green = new Color(60, 179, 113);
            Color blue = new Color(0, 0, 255);


            Sphere sphere = new Sphere(new Point(-70, 20, 2), 60, green);
            Sphere sphere2 = new Sphere(new Point(-10, 10, 4), 10, blue);
            Light light = new Light(new Vector(70, 80, 60));
            //Light light = new Light(new Vector(2, -3, -1));
            Camera camera = new Camera(new Point(20, -30, 15));
            Triangle triangle = new Triangle(new Point(-10, 5, -2), new Point(-10, 20, -2), new Point(-10, 12, 12));

            List<Point> vertexes = new List<Point>();
            List<Vector> normals = new List<Vector>();
            List<Triangle> triangles = new List<Triangle>();

            List<List<(int, int)>> triangleIndexes = new List<List<(int, int)>>();

            //ObjFileParser.ParseObjFile(sourceFileName, vertexes, normals, triangleIndexes).Wait();

            /*for (int i = 0; i < 10; i++)
            {
                int indexV1 = triangleIndexes[i][0].Item1 - 1;
                int indexV2 = triangleIndexes[i][1].Item1 - 1;
                int indexV3 = triangleIndexes[i][2].Item1 - 1;
                Triangle tria = new Triangle(vertexes[indexV1], vertexes[indexV2], vertexes[indexV3]);
                triangles.Add(tria);
            }

            Tracer tracer = new Tracer(camera, light, screen);

            foreach (Triangle t in triangles)
            {
                tracer.AddFigureToList(t);
            }*/

            Tracer tracer = new Tracer(camera, light, screen);
            tracer.AddFigureToList(sphere);
            tracer.AddFigureToList(sphere2);
            //tracer.AddFigureToList(triangle);

            tracer.render(data);


            //Console.WriteLine(triangleIndexes.Count());

            PpmFileWriter.WriteToFile(outputFileName, data).Wait();

        }
    }
}
