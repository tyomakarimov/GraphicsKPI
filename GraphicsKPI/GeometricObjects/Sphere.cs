using GraphicsKPI.Types;
using GraphicsKPI.Utils;

namespace GraphicsKPI.GeometricObjects
{
    internal class Sphere : IFigure
    {
        private Point center;
        private double radius;
        private readonly Color color;

        public Sphere(Point center, double radius, Color color)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
        }


        public bool CheckIntersectionWith(Ray ray, ref double t)
        {
            t = 0;
            var k = ray.origin - center;
            var b = ray.direction.Dot(k);
            var kAbs = k.abs;
            var Discriminant = 4 * (Math.Pow(b, 2) - Math.Pow(kAbs, 2) + Math.Pow(radius, 2));

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
            return (p - center).Normalize();
        }

        public Color GetColor()
        {
            return color;
        }
        
        public void Transform(Matrix matrix)
        {
            center = matrix.MultiplyPoint(center);
            radius *= Vector.Min(matrix.GetScaleVector());
        }

        public override string ToString()
        {
            return "Sphere";
        }
    }
}
