using GraphicsKPI.Types;
using System.Globalization;

namespace GraphicsKPI.Utils
{
    internal class ObjReader
    {
        public static async Task ReadFromFile(string fileName, List<Point> points, List<Vector> normals, List<List<(int, int)>> triangles)
        {
            var path = "D:\\Temporary\\Computer Graphics\\GraphicsKPI\\GraphicsKPI\\Utils\\Input\\" + fileName;

            using (var reader = new StreamReader(path))
            {
                string? line;
                const int scale = 300;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var coordinates = line.Split(' ');
                    if (line.StartsWith("v "))
                    {
                        var point = new Point(
                            double.Parse(coordinates[1], CultureInfo.InvariantCulture) * scale,
                            double.Parse(coordinates[2], CultureInfo.InvariantCulture) * scale,
                            double.Parse(coordinates[3], CultureInfo.InvariantCulture) * scale);
                        points.Add(point);
                    }
                    else if (line.StartsWith("vn "))
                    {
                        var vector = new Vector(
                            double.Parse(coordinates[1], CultureInfo.InvariantCulture) * scale,
                            double.Parse(coordinates[2], CultureInfo.InvariantCulture) * scale,
                            double.Parse(coordinates[3], CultureInfo.InvariantCulture) * scale);
                        normals.Add(vector);
                    }
                    else if (line.StartsWith("f "))
                    {
                        var triangle = new List<(int, int)>();
                        
                        var first = coordinates[1];
                        
                        var vertex1 = int.Parse(first.Split("//")[0]);
                        var normal1 = int.Parse(first.Split("//")[1]);
                        triangle.Add((vertex1, normal1));
                        
                        var second = coordinates[2];
                        
                        var vertex2 = int.Parse(second.Split("//")[0]);
                        var normal2 = int.Parse(second.Split("//")[1]);
                        triangle.Add((vertex2, normal2));

                        var third = coordinates[3];
                        
                        var vertex3 = int.Parse(third.Split("//")[0]);
                        var normal3 = int.Parse(third.Split("//")[1]);
                        triangle.Add((vertex3, normal3));

                        triangles.Add(triangle);
                    }
                }
            }
        }
    }
}
