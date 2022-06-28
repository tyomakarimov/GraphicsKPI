using GraphicsKPI.Types;

namespace GraphicsKPI.GeometricObjects
{
    interface IFigure
    {
        public bool CheckIntersectionWith(Ray ray, ref double t);
        public Vector GetNormalAtPoint(Point point);
        public Color GetColor();
    }
}
