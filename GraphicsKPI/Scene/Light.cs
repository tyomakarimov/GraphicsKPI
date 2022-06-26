using GraphicsKPI.Types;

namespace GraphicsKPI.Scene
{
    internal class Light
    {
        public Vector direction { get; private set; }
        public Light(Vector direction)
        {
            this.direction = direction.Normalize();
        }
    }
}
