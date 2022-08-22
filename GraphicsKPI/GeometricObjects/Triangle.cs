using GraphicsKPI.Types;


namespace GraphicsKPI.GeometricObjects
{
    internal class Triangle : IFigure
    {
        private Point _v1;
        private Point _v2;
        private Point _v3;
        private Vector _normal1;
        private Vector _normal2;
        private Vector _normal3;
        private Color _color;
        private double EPSILON = 0.0000001;

        public Triangle (Point v1, Point v2, Point v3)
        {
            _v1 = v1;
            _v2 = v2;
            _v3 = v3;
        }
        
        public Triangle(Point v1, Point v2, Point v3, Vector n1, Vector n2, Vector n3)
        {
            _v1 = v1;
            _v2 = v2;
            _v3 = v3;
            _normal1 = n1;
            _normal2 = n2;
            _normal3 = n3;
            _color = new Color(153, 255, 204);
        }

        public bool CheckIntersectionWith(Ray ray, ref double t)
        {
            t = 0;
            var edge1 = _v2 - _v1;
            var edge2 = _v3 - _v1;

            var h = ray.direction.CrossProduct(edge2);
            var a = edge1.Dot(h);
            if (a > -EPSILON && a < EPSILON)
            {
                return false;
            }

            var f = 1.0 / a;
            var s = ray.origin - _v1;
            var u = f * s.Dot(h);

            if (u < 0.0 || u > 1.0)
            {
                return false;
            }

            var q = s.CrossProduct(edge1);
            var v = f * ray.direction.Dot(q);
            if (v < 0.0 || u + v > 1.0)
            {
                return false;
            }


            t = f * edge2.Dot(q);
            return t > EPSILON;
        }


        public Vector GetNormalAtPoint(Point p)
        {
            Vector edge1 = _v2 - p;
            Vector edge2 = _v3 - p;
            return edge1.CrossProduct(edge2).Normalize();
        }

        public Color GetColor()
        {
            return _color;
        }

        public override string ToString()
        {
            return "Triangle";
        }

    }
}
