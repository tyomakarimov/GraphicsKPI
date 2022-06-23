namespace GraphicsKPI.Entities
{
    internal class Camera
    {
        private Point _location;
        public Point Location
        {
            get => _location;
            set => _location = value;
        }

        public Camera(Point location)
        {
            _location = location;
        } 
    }
}
