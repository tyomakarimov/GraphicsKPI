
namespace GraphicsKPI.Types
{
    internal class Color
    {
        public int r { get; private set; }
        public int g { get; private set; }
        public int b { get; private set; }

        public Color (int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
