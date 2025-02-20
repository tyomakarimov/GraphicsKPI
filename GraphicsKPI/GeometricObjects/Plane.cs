﻿using GraphicsKPI.Types;
using GraphicsKPI.Utils;

namespace GraphicsKPI.GeometricObjects
{
    internal class Plane : IFigure
    {
        private Point _center;
        private Vector _normal;
        private Color _color;

        public Vector Normal
        {
            get => _normal;
            set => _normal = value.Normalize();
        }

        public Plane(Point point, Vector vector)
        {
            _center = point;
            _normal = vector.Normalize();
            _color = new Color(0, 255, 0);
        }

        public bool CheckIntersectionWith(Ray ray, ref double t)
        {
            double denom = _normal.Dot(ray.direction);
            if (Math.Abs(denom) > 0.0001f)
            {
                t = (_center - ray.origin).Dot(_normal) / denom;
                if (t >= 0) return true;
            }
            return false;
        }

        public Vector GetNormalAtPoint(Point point)
        {
            return _normal;
        }
        
        public Color GetColor()
        {
            return _color;
        }

        public void Transform(Matrix matrix)
        {
            _center = matrix.MultiplyPoint(_center);
            _normal = matrix.MultiplyVector(_normal);
        }
    }
}
