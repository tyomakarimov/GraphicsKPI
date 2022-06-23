namespace GraphicsKPI.Entities
{
    internal class Plane
    {
        private Point _point;
        private double _height;
        private double _width;

        public Plane(Point point, double height, double width)
        {
            _point = point;
            _height = height;
            _width = width;
        }
    }
}
