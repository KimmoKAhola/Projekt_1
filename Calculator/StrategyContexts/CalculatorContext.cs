﻿using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Mathematics.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.StrategyContexts
{
    public class CalculatorContext
    {
        public CalculatorContext(IMath? strategy)
        {
            Strategy = strategy;
        }
        public IMath? Strategy { get; private set; }
        public char Operator { get; private set; }
        private static IMath? CreateStrategy(char choice)
        {
            return choice switch
            {
                '+' => new Addition(),
                '-' => new Subtraction(),
                '*' => new Multiplication(),
                '÷' => new Division(),
                '%' => new Modulus(),
                '√' => new SquareRoot(),
                'E' => null,
                _ => null,
            };
        }

        public void SetStrategy(char choice)
        {
            Strategy = CreateStrategy(choice);
            if (Strategy != null)
                Operator = Strategy.Operator;
        }

        public double ExecuteStrategy(double first, double second)
        {
            return Math.Round(Strategy.Calculate(first, second), 2);
        }
    }
}