using GraphicsKPI.Types;

namespace GraphicsKPI.Utils
{
    internal class Matrix
    {
        private double[,]? _matrix;

        public Matrix()
        {
            _matrix = null;
        }
        
        public void Scale(Vector vector)
        {
            double[,] matrix = {
                { vector.x, 0, 0, 0 },
                { 0, vector.y, 0, 0 },
                { 0, 0, vector.z, 0 },
                { 0, 0, 0, 1 }
            };
            if (_matrix is null)
            {
                _matrix = matrix;
            }
            else
            {
                MultiplyMatrix(matrix);
            }
        }

        public void RotateX(double angle)
        {
            var radians = Math.PI * angle / 180;
            double[,] matrix = {
                { Math.Cos(radians), -Math.Sin(radians), 0, 0 },
                { Math.Sin(radians), Math.Cos(radians), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            if (_matrix is null)
            {
                _matrix = matrix;
            }
            else
            {
                MultiplyMatrix(matrix);
            }
        }

        public void RotateY(double angle)
        {
            var radians = Math.PI * angle / 180;
            double[,] matrix = {
                { Math.Cos(radians), 0, Math.Sin(radians), 0 },
                { 0, 1, 0, 0 },
                { -Math.Sin(radians), 0, Math.Cos(radians), 0 },
                { 0, 0, 0, 1 }
            };
            if (_matrix is null)
            {
                _matrix = matrix;
            }
            else
            {
                MultiplyMatrix(matrix);
            }
        }

        public void RotateZ(double angle)
        {
            var radians = Math.PI * angle / 180;
            double[,] matrix = {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(radians), -Math.Sin(radians), 0 },
                { 0, Math.Sin(radians), Math.Cos(radians), 0 },
                { 0, 0, 0, 1 }
            };
            if (_matrix is null)
            {
                _matrix = matrix;
            }
            else
            {
                MultiplyMatrix(matrix);
            }
        }
        
        public void Translate(Vector vector) 
        {
            double[,] matrix = {
                { 1, 0, 0, vector.x },
                { 0, 1, 0, vector.y },
                { 0, 0, 1, vector.z },
                { 0, 0, 0, 1 }
            };
            if (_matrix is null)
            {
                _matrix = matrix;
            } else
            {
                MultiplyMatrix(matrix);
            }
        }

        private void MultiplyMatrix(double[,] secondMatrix)
        {
            if (_matrix is not null)
            {
                var result = new double[_matrix.GetLength(0), secondMatrix.GetLength(1)];
                
                for (var i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (var j = 0; j < secondMatrix.GetLength(1); j++)
                    {
                        result[i, j] = 0;
                        
                        for (var k = 0; k < _matrix.GetLength(1); k++)
                        {
                            result[i, j] += _matrix[i, k] * secondMatrix[k, j];
                        }
                    }
                }
                _matrix = result;   
            }
        }

        public Vector MultiplyVector(Vector vector)
        {
            if (_matrix is null) return vector;
            var result = new double[_matrix.GetLength(0)];
            double[] vector4 =
            {
                vector.x,
                vector.y,
                vector.z,
                1
            };
            for (var row = 0; row < result.Length; row++)
            {
                result[row] = 0;
                for (var i = 0; i < 4; i++)
                {
                    result[row] += _matrix[row, i] * vector4[i];
                }
            }
            return new Vector(result[0], result[1], result[2]).Normalize();
        }

        public Point MultiplyPoint(Point point)
        {
            if (_matrix is null) return point;
            var result = new double[_matrix.GetLength(0)];
            double[] vector =
            {
                point.x,
                point.y,
                point.z,
                1
            };
            for (var row = 0; row < result.Length; row++)
            {
                result[row] = 0;
                for (var i = 0; i < 4; i++)
                {
                    result[row] += _matrix[row, i] * vector[i];
                }
            }
            return new Point(result[0], result[1], result[2]);
        }
    }
}
