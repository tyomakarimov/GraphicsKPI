using GraphicsKPI.Types;

namespace GraphicsKPI.GeometricObjects
{
    internal class Plane : IFigure
    {
        private Point _center;
        private Vector _normal;

        public Vector Normal
        {
            get => _normal;
            set => _normal = value.Normalize();
        }

        public Plane(Point point, Vector vector)
        {
            _center = point;
            _normal = vector.Normalize();
        }

        public bool CheckIntersectionWith(Ray ray, ref double t)
        {
            double denom = _normal.Dot(ray.direction);
            if (Math.Abs(denom) > 1e-6)
            {
                t = (_center - ray.origin).Dot(_normal) / denom;
                if (t >= 0) return true;
            }
            return false;
        }

        public Vector GetNormalAtPoint(Point point)
        {
            return _normal;
        }
    }
}
