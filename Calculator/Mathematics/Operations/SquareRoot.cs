﻿using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class SquareRoot : IMath
    {
        public char Operator => '√';
        public double Calculate(double first, double second)
        {
            if (second > 0)
                return Math.Pow(first, 1 / second);
            else
                return double.NaN;
        }
    }
}