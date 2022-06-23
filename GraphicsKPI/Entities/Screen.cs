namespace GraphicsKPI.Entities
{
    internal class Screen
    {
        private Point point { get; }
        private int height { get; }
        private int width { get; }

        public Screen(Point point, int height, int width)
        {
            this.point = point;
            this.height = height;
            this.width = width;
        }
    }
}