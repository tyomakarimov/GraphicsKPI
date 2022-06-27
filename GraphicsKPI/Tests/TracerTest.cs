using System;
using NUnit.Framework;
using GraphicsKPI.GeometricObjects;
using GraphicsKPI.Scene;
using GraphicsKPI.Types;


namespace GraphicsKPI.Tests
{
    internal class TracerTest
    {
        private Point _origin;
        private Camera _camera;
        private Light _light;
        private Screen _screen;


        [SetUp]
        public void Setup()
        {
            _origin = new Point(20, 10, 15);
            _camera = new Camera(_origin);
            Point screenCenter = new Point(-15, 15, 7);
            _light = new Light(new Vector(38, 15, 60));
            int width = 30;
            int height = 30;
            _screen = new Screen(screenCenter, height, width);
        }

        [Test]
        public void TraceSingleObject()
        {
            Sphere sphere = new Sphere(new Point(-40, 20, 2), 12);
            Tracer tracer = new Tracer(_camera, _light, _screen);
            tracer.AddFigureToList(sphere);


            char[,] charList = new char[_screen.Width, _screen.Height];
            //tracer.ProcessSingleObject(_origin, charList);

            //Assert.AreEqual(charList[14, 14], 'O');

        }

        [Test]
        public void TraceMultipleObjects()
        {
            Sphere sphere = new Sphere(new Point(-40, 20, 2), 12);
            Point D = new Point(-25, 22, 10);
            Point C = new Point(-20, 30, -5);
            Point E = new Point(-20, 0, 0);
            Triangle triangle = new Triangle(D, C, E);

            List<IFigure> figureList = new List<IFigure>();

            figureList.Add(sphere);
            figureList.Add(triangle);


            IFigure closestObj = null;

            Point dest = new Point(-15, 15, 7); // screen center
            Vector direction = dest - _origin;
            Ray ray = new Ray(_origin, direction);

            double tval = double.MaxValue;

            for (int i = 0; i < figureList.Count(); i++)
            {
                double temptval = 0.0;
                if (figureList[i].CheckIntersectionWith(ray, ref temptval))
                {
                    if (temptval < tval)
                    {
                        tval = temptval;
                        closestObj = figureList[i];
                    }
                }
            }

            Assert.AreEqual(closestObj.ToString(), "Triangle");
        }

    }
}
