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

            Color blue = new Color(0, 0, 255);
            Color bluePurple = new Color(106, 90, 205);
            Color red = new Color(255, 0, 0);
            Color green = new Color(0, 255, 0);


            Sphere sphere = new Sphere(new Point(-70, 20, 2), 60, green);
            Sphere sphere2 = new Sphere(new Point(-10, 10, 4), 10, blue);
            Light light = new Light(new Vector(30, 80, 40));
            //Light light = new Light(new Vector(2, -3, -1));
            Camera camera = new Camera(new Point(30, 15, 15));
            Triangle triangle = new Triangle(new Point(-10, 5, -2), new Point(-10, 20, -2), new Point(-10, 12, 12));

            Point A = new Point(-70, -50, -20);
            Point D = new Point(-70, 70 ,-20);
            Point H = new Point(-80, 50, 100);

            Triangle triangle2 = new Triangle(A, D, H, bluePurple);
            Sphere sphere3 = new Sphere(new Point(-50, 40, 10), 20, red);

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

            Matrix matrix = new Matrix();
            //matrix.Scale(new Vector(2, 2, 2));

            //triangle2.Transform(matrix);


            Tracer tracer = new Tracer(camera, light, screen);
            tracer.AddFigureToList(triangle2);
            tracer.AddFigureToList(sphere3);

            tracer.render(data);


            //Console.WriteLine(triangleIndexes.Count());

            PpmFileWriter.WriteToFile(outputFileName, data).Wait();

        }
    }
}
