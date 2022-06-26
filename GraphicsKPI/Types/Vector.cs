namespace GraphicsKPI.Types
{
    internal class Vector
    {
        public double x;
        public double y;
        public double z;
        public double abs;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            abs = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }


        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public double AddByModulus(Vector v, double alpha)
        {
            return Math.Pow(abs, 2) + Math.Pow(v.abs, 2) + 2 * abs * v.abs * Math.Cos(alpha);
        }

        public double SubstractByModulus(Vector v, double alpha)
        {
            return Math.Pow(abs, 2) + Math.Pow(v.abs, 2) - 2 * abs * v.abs * Math.Cos(alpha);
        }

        public Vector MultiplyBy(double number)
        {
            return new Vector(number * x, number * y, number * z);
        }

        public double Dot(Vector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vector CrossProduct(Vector v)
        {
            return new Vector(y * v.z - z * v.y, z * v.x - x * v.z, x * v.y - y * v.x);
        }

        public Vector Normalize()
        {
            return new Vector(x / abs, y / abs, z / abs);
        }
    }
}
