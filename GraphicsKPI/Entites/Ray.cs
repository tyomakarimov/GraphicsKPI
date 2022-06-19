using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsKPI.Entites
{
    internal class Ray
    {
        public Point origin { get; private set; }
        public Vector direction { get; private set; }

        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
}
