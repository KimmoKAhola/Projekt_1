﻿using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Parallelogram : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateArea(double width, double height)
        {
            return width * height;
        }

        public double CalculateCircumference(double width, double height)
        {
            return (2 * width + 2 * height);
        }
    }
}