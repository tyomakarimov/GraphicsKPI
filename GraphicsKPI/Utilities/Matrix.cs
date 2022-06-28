using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraphicsKPI.Types;

namespace GraphicsKPI.Utilities
{
    internal class Matrix
    {
        public double[,]? matrix;
        private int rows;
        private int cols;

        public Matrix()
        {
            matrix = null;
        }

        public void MultiplyMatrix(double[,] secondMatrix)
        {
            double[,] result = new double[matrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        result[i, j] += matrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            matrix = result;

        }

        public Vector MultiplyVector(Vector v)
        {
            double[] result = new double[matrix.GetLength(0)];
            double[] vector4 = new double[] { v.x, v.y, v.z, 1 };
            for (int row = 0; row < result.Length; row++)
            {
                result[row] = 0;
                for (int i = 0; i < 4; i++)
                {
                    result[row] += matrix[row, i] * vector4[i];
                }
            }

            return new Vector(result[0], result[1], result[2]).Normalize();
        }

        public Point MultiplyPoint(Point p)
        {
            double[] result = new double[matrix.GetLength(0)];
            double[] vector4 = new double[] { p.x, p.y, p.z, 1 };
            for (int row = 0; row < result.Length; row++)
            {
                result[row] = 0;
                for (int i = 0; i < 4; i++)
                {
                    result[row] += matrix[row, i] * vector4[i];
                }
            }

            return new Point(result[0], result[1], result[2]);
        }

        public void Move(Vector v) 
        {
            double[,] moveMatrix = {
                {1,0,0,v.x},
                {0,1,0,v.y},
                {0,0,1,v.z},
                {0,0,0,1}
            };
            if (matrix is null)
            {
                matrix = moveMatrix;
            } else
            {
                MultiplyMatrix(moveMatrix);
            }
        }

        public void Scale(Vector v)
        {
            double[,] scaleMatrix = {
                {v.x,0,0,0},
                {0,v.y,0,0},
                {0,0,v.z,0},
                {0,0,0,1}
            };
            if (matrix is null)
            {
                matrix = scaleMatrix;
            }
            else
            {
                MultiplyMatrix(scaleMatrix);
            }
        }

        public void RotateX(double alpha)
        {
            double radians = (Math.PI / 180) * alpha;
            double[,] rotationMatrix = {
                {Math.Cos(radians), -Math.Sin(radians),0,0},
                {Math.Sin(radians), Math.Cos(radians),0,0},
                {0,0,1,0},
                {0,0,0,1}
            };
            if (matrix is null)
            {
                matrix = rotationMatrix;
            }
            else
            {
                MultiplyMatrix(rotationMatrix);
            }
        }

        public void RotateY(double alpha)
        {
            double radians = (Math.PI / 180) * alpha;
            double[,] rotationMatrix = {
                {Math.Cos(radians),0, Math.Sin(radians), 0},
                {0,1,0,0},
                {-Math.Sin(radians),0, Math.Cos(radians), 0},
                {0,0,0,1}
            };
            if (matrix is null)
            {
                matrix = rotationMatrix;
            }
            else
            {
                MultiplyMatrix(rotationMatrix);
            }
        }


        public void RotateZ(double alpha)
        {
            double radians = (Math.PI / 180) * alpha;
            double[,] rotationMatrix = {
                {1,0,0,0},
                {0, Math.Cos(radians), -Math.Sin(radians), 0},
                {0, Math.Sin(radians), Math.Cos(radians), 0},
                {0,0,0,1}
            };
            if (matrix is null)
            {
                matrix = rotationMatrix;
            }
            else
            {
                MultiplyMatrix(rotationMatrix);
            }
        }

    }
}
