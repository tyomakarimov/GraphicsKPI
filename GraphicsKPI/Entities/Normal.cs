namespace GraphicsKPI.Entities
{
    internal class Normal : Vector
    {
        public Normal(double x, double y, double z) : base(x, y, z)
        {
            normilize();
        }
    }
}
