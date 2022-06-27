using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;

namespace GraphicsKPI.Utilities
{
    internal class PpmFileWriter
    {
        public static async Task WriteToFile(string fileName, Color[,] matrix)
        {
            string PATH = "C:\\Users\\maxsh\\source\\repos\\GraphicsKPI\\GraphicsKPI\\Utilities\\Results\\" + fileName;

            string p3 = "P3";
            string widthAndHeight = "" + matrix.GetLength(1) +  " " + matrix.GetLength(0);
            string maxNum = "255";

            using (StreamWriter writer = new StreamWriter(PATH, false))
            {
                await writer.WriteLineAsync(p3);
                await writer.WriteLineAsync(widthAndHeight);
                await writer.WriteLineAsync(maxNum);
            }


            using (StreamWriter writer = new StreamWriter(PATH, true))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Color pixel = matrix[i, j];
                        string color = string.Format("{0} {1} {2}", pixel.r, pixel.g, pixel.b);
                        await writer.WriteLineAsync(color);
                    }
                }
            }
           
        }
        
    }
}
