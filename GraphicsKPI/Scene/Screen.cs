using GraphicsKPI.Types;

namespace GraphicsKPI.Scene
{
    internal class Screen
    {

        private Point _center;
        private int _height;
        private int _width;

        public Screen(Point center, int height, int width)
        {
            _center = center;
            _height = height;
            _width = width;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }


        //right-handed coordinates

        public Point GetPointByScreenCoord(int x, int y)
        {
            double yCoordOfStart = _center.y - (double)_width / 2 + 0.5;
            double zCoordOfStart = _center.z + (double)_height / 2 - 0.5;
            return new Point(_center.x, yCoordOfStart + y, zCoordOfStart - x);
        }
    }
}