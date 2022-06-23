namespace GraphicsKPI.Entities
{
    internal class Ray
    {
        public Point origin { get; }
        public Vector direction { get; }

        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Point getPointByT(double t)
        {
            var vector = direction.multiplyBy(t);
            return origin.add(vector);
        }
    }
}
