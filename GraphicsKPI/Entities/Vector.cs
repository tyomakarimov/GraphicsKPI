namespace GraphicsKPI.Entities
{
    internal class Vector
    {
        public readonly double x;
        public readonly double y;
        public readonly double z;
        public readonly double modulus;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            modulus = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }


        public Vector addTo(Vector v)
        {
            return new Vector(x + v.x, y + v.y, z + v.z);
        }

        public Vector subract(Vector v)
        {
            return new Vector(x - v.x, y - v.y, z - v.z);
        }

        public double addByModulus(Vector v, double alpha)
        {
            return Math.Pow(modulus, 2) + Math.Pow(v.modulus, 2) + (2 * modulus * v.modulus * Math.Cos(alpha));
        }

        public double substractByModulus(Vector v, double alpha)
        {
            return Math.Pow(modulus, 2) + Math.Pow(v.modulus, 2) - (2 * modulus * v.modulus * Math.Cos(alpha));
        }

        public Vector multiplyBy(double number)
        {
            return new Vector(number * x, number * y, number * z);
        }

        public double scalarMultiplication(Vector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vector crossProduct(Vector v)
        {
            return new Vector(y * v.z - z * v.y, z * v.x - x * v.z, x * v.y - y * v.x);
        }

        public Vector normilize()
        {
            return new Vector(x / modulus, y / modulus, z / modulus);
        }
    }
}
