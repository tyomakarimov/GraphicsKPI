using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using System.Globalization;


namespace GraphicsKPI.Utilities
{
    internal class ObjFileParser
    {
        public static async Task ParseObjFile(string fileName, List<Point> vertexes, List<Vector> normals, List<List<(int, int)>> triangleIndexes)
        {
            string PATH = "C:\\Users\\maxsh\\source\\repos\\GraphicsKPI\\GraphicsKPI\\Utilities\\Sources\\" + fileName;

            using (StreamReader reader = new StreamReader(PATH))
            {
                string? line;
                int scale = 300;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line.StartsWith("v "))
                    {
                        string vertex = line.Substring(line.IndexOf(' ') + 1);
                        string xCoord = vertex.Substring(0, vertex.IndexOf(' '));
                        string remainYZ = vertex.Substring(vertex.IndexOf(' ') + 1);
                        string yCoord = remainYZ.Substring(0, remainYZ.IndexOf(' '));
                        string zCoord = remainYZ.Substring(remainYZ.IndexOf(' ') + 1);
                        Point point = new Point(
                            double.Parse(xCoord, CultureInfo.InvariantCulture) * scale,
                            double.Parse(yCoord, CultureInfo.InvariantCulture) * scale,
                            double.Parse(zCoord, CultureInfo.InvariantCulture) * scale);
                        vertexes.Add(point);
                    }
                    else if (line.StartsWith("vn "))
                    {
                        string normal = line.Substring(line.IndexOf(' ') + 1);
                        string xCoord = normal.Substring(0, normal.IndexOf(' '));
                        string remainYZ = normal.Substring(normal.IndexOf(' ') + 1);
                        string yCoord = remainYZ.Substring(0, remainYZ.IndexOf(' '));
                        string zCoord = remainYZ.Substring(remainYZ.IndexOf(' ') + 1);
                        Vector norm = new Vector(
                            double.Parse(xCoord, CultureInfo.InvariantCulture) * scale,
                            double.Parse(yCoord, CultureInfo.InvariantCulture) * scale,
                            double.Parse(zCoord, CultureInfo.InvariantCulture) * scale);
                        normals.Add(norm);
                    }
                    else if (line.StartsWith("f "))
                    {
                        string face = line.Substring(line.IndexOf(' ') + 1);
                        List<(int, int)> triangle = new List<(int, int)>();

                        string firstIndexes = face.Substring(0, face.IndexOf(' '));
                        string remainIndexes = face.Substring(face.IndexOf(' ') + 1);
                        string secondIndexes = remainIndexes.Substring(0, remainIndexes.IndexOf(' '));
                        string thirdIndexes = remainIndexes.Substring(remainIndexes.IndexOf(' ') + 1);

                        int v1 = int.Parse(firstIndexes.Substring(0, firstIndexes.IndexOf("//")));
                        int n1 = int.Parse(firstIndexes.Substring(firstIndexes.IndexOf("//") + 2));
                        triangle.Add((v1, n1));

                        int v2 = int.Parse(secondIndexes.Substring(0, secondIndexes.IndexOf("//")));
                        int n2 = int.Parse(secondIndexes.Substring(secondIndexes.IndexOf("//") + 2));
                        triangle.Add((v2, n2));

                        int v3 = int.Parse(thirdIndexes.Substring(0, thirdIndexes.IndexOf("//")));
                        int n3 = int.Parse(thirdIndexes.Substring(thirdIndexes.IndexOf("//") + 2));
                        triangle.Add((v3, n3));

                        triangleIndexes.Add(triangle);

                    }
                }
            }
        }
    }
}
