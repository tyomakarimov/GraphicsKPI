using NUnit.Framework;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Types;

namespace GraphicsKPI.Tests
{
    internal class TriangleTest
    {
        private Triangle _triangle;
        private Point _origin;


        [SetUp]
        public void Setup()
        {
            _origin = new Point(20, 10, 15);
            Point D = new Point(-7, 15, 10);
            Point C = new Point(-5, 20, -5);
            Point E = new Point(-20, 0, 0);
            _triangle = new Triangle(D, C, E);
        }

        [Test]
        public void DestPointAfterObject()
        {
            Point dest = new Point(-25, 15, -5);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _triangle.CheckIntersectionWith(ray, ref t);
            Point intersection = ray.GetPointByT(t);

            double tolerance = 0.005;

            Assert.AreEqual(result, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-9.38 - tolerance, -9.38 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(13.26 - tolerance, 13.26 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(1.94 - tolerance, 1.94 + tolerance));

        }

        [Test]
        public void DestPointBeforeObject()
        {
            Point dest = new Point(-5, 15, 3);
            Point dest2 = new Point(5, 10, 10);
            double t = 0.0;
            double t2 = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Vector rayDirection2 = (dest2 - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);
            Ray ray2 = new Ray(_origin, rayDirection2);

            bool result = _triangle.CheckIntersectionWith(ray, ref t);
            bool result2 = _triangle.CheckIntersectionWith(ray2, ref t2);
            Point intersection = ray.GetPointByT(t);
            Point intersection2 = ray2.GetPointByT(t2);

            double tolerance = 0.005;

            Assert.AreEqual(result, true);
            Assert.AreEqual(result2, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-7.64 - tolerance, -7.64 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(15.53 - tolerance, 15.53 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(1.73 - tolerance, 1.73 + tolerance));
            Assert.That(Math.Round(intersection2.x, 3), Is.InRange(-11.61 - tolerance, -11.61 + tolerance));
            Assert.That(Math.Round(intersection2.y, 3), Is.InRange(10 - tolerance, 10 + tolerance));
            Assert.That(Math.Round(intersection2.z, 3), Is.InRange(4.46 - tolerance, 4.46 + tolerance));
        }

        [Test]
        public void NoIntersection()
        {
            Point dest = new Point(-5, 20, 3);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _triangle.CheckIntersectionWith(ray, ref t);

            Assert.AreEqual(result, false);
        }
    }
}
