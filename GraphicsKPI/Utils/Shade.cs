using GraphicsKPI.Types;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;

namespace GraphicsKPI.Utils
{
    internal class Shade
    {
        public static Color GetColorWithShade(
            Vector normal, Point intersectionPoint, IFigure closestFigure, Light light, List<IFigure> figures)
        {
            var point = intersectionPoint + normal.MultiplyBy(0.001f);
            var ray = new Ray(point, light.direction);

            var dotProduct = Math.Max(light.direction.Dot(normal), 0.0);
            if (dotProduct > 0.0 && RayIntersectsFigure(ray, figures)) return new Color(0, 0, 0);
            
            var figureColor = closestFigure.GetColor();
            
            var r = (int)Math.Ceiling(figureColor.r * dotProduct);
            var g = (int)Math.Ceiling(figureColor.g * dotProduct);
            var b = (int)Math.Ceiling(figureColor.b * dotProduct);
            
            return new Color(r, g, b);
        }
        
        private static bool RayIntersectsFigure(Ray ray, List<IFigure> figures)
        {
            var t = 0.0;
            foreach (var figure in figures)
            {
                if (figure.CheckIntersectionWith(ray, ref t)) return true;
            }
            return false;
        }
    }
}