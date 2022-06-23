namespace GraphicsKPI.Entities
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

        public Point add(Vector v)
        {
            return new Point(x + v.x, y + v.y, z + v.z);
        }

        public Vector subtract(Point p)
        {
            return new Vector(x - p.x, y - p.y, z - p.z);
        }
    }
}
