using GraphicsKPI.Types;

namespace GraphicsKPI.Utils
{
    internal class PpmWriter
    {
        public static async Task WriteToFile(string fileName, Color[,] matrix)
        {
            var path = "D:\\Temporary\\Computer Graphics\\GraphicsKPI\\GraphicsKPI\\Utils\\Output\\" + fileName;

            const string p3 = "P3";
            var widthAndHeight = "" + matrix.GetLength(1) +  " " + matrix.GetLength(0);
            const string maxNum = "255";

            using (var writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(p3);
                await writer.WriteLineAsync(widthAndHeight);
                await writer.WriteLineAsync(maxNum);
            }

            using (var writer = new StreamWriter(path, true))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        var pixel = matrix[i, j];
                        var color = string.Format("{0} {1} {2}", pixel.r, pixel.g, pixel.b);
                        await writer.WriteLineAsync(color);
                    }
                }
            }
        }
    }
}