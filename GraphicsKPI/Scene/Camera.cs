using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;

namespace GraphicsKPI.Scene
{
    internal class Camera
    {
        public Point _location { get; private set; }

        public Camera(Point location)
        {
            _location = location;
        }
    }
}
