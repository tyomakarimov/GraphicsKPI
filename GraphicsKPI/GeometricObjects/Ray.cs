using GraphicsKPI.Types;

namespace GraphicsKPI.GeometricObjects
{
    internal class Ray
    {
        public Point origin { get; }
        public Vector direction { get; }

        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction.Normalize();
        }

        public Point GetPointByT(double t)
        {
            var vector = direction.MultiplyBy(t);
            return origin + vector;
        }
    }
}
