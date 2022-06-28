using GraphicsKPI.Types;

namespace GraphicsKPI.GeometricObjects
{
    internal class Sphere : IFigure
    {
        private Point _center;
        private double _radius;
        private Color _color;

        public Sphere(Point center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public Sphere(Point center, double radius, Color color) : this(center, radius)
        {
            _color = color;
        }


        public bool CheckIntersectionWith(Ray ray, ref double t)
        {
            t = 0;
            var k = ray.origin - _center;
            var b = ray.direction.Dot(k);
            var kAbs = k.abs;
            var Discriminant = 4 * (Math.Pow(b, 2) - Math.Pow(kAbs, 2) + Math.Pow(_radius, 2));

            if (Discriminant < 0) return false;

            var sqrtDiscriminant = Math.Sqrt(Discriminant);
            var t1 = -b - sqrtDiscriminant / 2;
            var t2 = -b + sqrtDiscriminant / 2;

            if (t1 < 0 && t2 < 0) return false;
            t = t1 < 0 ? t2 : t1;
            return true;
        }
        public Vector GetNormalAtPoint(Point p)
        {
            return (p - _center).Normalize();
        }
        public Color GetColor()
        {
            return _color;
        }

        public override string ToString()
        {
            return "Sphere";
        }
    }
}
