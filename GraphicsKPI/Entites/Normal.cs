﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsKPI.Entites
{
    internal class Normal : Vector
    {
        public Normal(double x, double y, double z) : base(x, y, z)
        {
            normilize();
        }
    }
}
