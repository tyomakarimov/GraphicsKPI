namespace GraphicsKPI.Types
{
    internal class Point
    {
        public double x;
        public double y;
        public double z;

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.x + v.x, p.y + v.y, p.z + v.z);
        }

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }

        public override string ToString()
        {
            return "(" + x + ";" + y + ";" + z + ")";
        }
    }
}
