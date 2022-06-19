using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsKPI.Entites
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
