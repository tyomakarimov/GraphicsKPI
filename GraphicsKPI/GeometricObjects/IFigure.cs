using GraphicsKPI.Types;
using GraphicsKPI.Utils;

namespace GraphicsKPI.GeometricObjects
{
    interface IFigure
    {
        public bool CheckIntersectionWith(Ray ray, ref double t);
        public Vector GetNormalAtPoint(Point point);
        
        public Color GetColor();

        public void Transform(Matrix matrix);
    }
}
