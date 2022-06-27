using System;
using NUnit.Framework;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using GraphicsKPI.Types;


namespace GraphicsKPI.Tests
{
    internal class SphereTest
    {
        private Sphere _sphere;
        private Point _origin;


        [SetUp]
        public void Setup()
        {
            _origin = new Point(20, 10, 15);
            _sphere = new Sphere(new Point(-15, 16, 2), 9);
        }

        [Test]
        public void DestPointAfterObject()
        {
            Point dest = new Point(-25, 15, -5);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _sphere.CheckIntersectionWith(ray, ref t);
            Point intersection = ray.GetPointByT(t);

            double tolerance = 0.003;

            Assert.AreEqual(result, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-6.61 - tolerance, -6.61 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(12.96 - tolerance, 12.96 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(3.17 - tolerance, 3.17 + tolerance));

        }

        [Test]
        public void DestPointBeforeObject()
        {
            Point dest = new Point(-3, 16, 7);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _sphere.CheckIntersectionWith(ray, ref t);
            Point intersection = ray.GetPointByT(t);

            double tolerance = 0.004;

            Assert.AreEqual(result, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-6.84 - tolerance, -6.84 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(17 - tolerance, 17 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(5.66 - tolerance, 5.66 + tolerance));
        }

        [Test]
        public void NoIntersection()
        {
            Point dest = new Point(10, 12, 7);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _sphere.CheckIntersectionWith(ray, ref t);

            Assert.AreEqual(result, false);
        }
    }
}
