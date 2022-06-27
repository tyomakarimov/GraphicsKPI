using NUnit.Framework;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Types;

namespace GraphicsKPI.Tests
{
    internal class PlaneTest
    {
        private Plane _plane;
        private Point _origin;


        [SetUp]
        public void Setup()
        {
            _origin = new Point(20, 10, 15);
            Point D = new Point(-7, 15, 10);
            Vector vector = new Vector(-6.08, 4.75, 0.77);
            _plane = new Plane(D, vector);
        }

        [Test]
        public void DestPointAfterObject()
        {
            Point dest = new Point(-25, 14, -5);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _plane.CheckIntersectionWith(ray, ref t);
            Point intersection = ray.GetPointByT(t);

            double tolerance = 0.005;

            Assert.AreEqual(result, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-9.88 - tolerance, -9.88 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(12.66 - tolerance, 12.66 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(1.72 - tolerance, 1.72 + tolerance));

        }

        [Test]
        public void DestPointBeforeObject()
        {
            Point dest = new Point(7, 14, -5);
            Point dest2 = new Point(5, 10, 10);
            double t = 0.0;
            double t2 = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Vector rayDirection2 = (dest2 - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);
            Ray ray2 = new Ray(_origin, rayDirection2);

            bool result = _plane.CheckIntersectionWith(ray, ref t);
            bool result2 = _plane.CheckIntersectionWith(ray2, ref t2);
            Point intersection = ray.GetPointByT(t);
            Point intersection2 = ray2.GetPointByT(t2);

            double tolerance = 0.005;

            Console.WriteLine(intersection);
            Assert.AreEqual(result, true);
            Assert.AreEqual(result2, true);
            Assert.That(Math.Round(intersection.x, 3), Is.InRange(-8.95 - tolerance, -8.95 + tolerance));
            Assert.That(Math.Round(intersection.y, 3), Is.InRange(18.91 - tolerance, 18.91 + tolerance));
            Assert.That(Math.Round(intersection.z, 3), Is.InRange(-29.55 - tolerance, -29.55 + tolerance));
            Assert.That(Math.Round(intersection2.x, 3), Is.InRange(-11.61 - tolerance, -11.61 + tolerance));
            Assert.That(Math.Round(intersection2.y, 3), Is.InRange(10 - tolerance, 10 + tolerance));
            Assert.That(Math.Round(intersection2.z, 3), Is.InRange(4.46 - tolerance, 4.46 + tolerance));
        }

        [Test]
        public void NoIntersection()
        {
            Point dest = new Point(-29, -49.73, -5);
            double t = 0.0;

            Vector rayDirection = (dest - _origin).Normalize();
            Ray ray = new Ray(_origin, rayDirection);

            bool result = _plane.CheckIntersectionWith(ray, ref t);

            Assert.AreEqual(result, false);
        }
    }
}
