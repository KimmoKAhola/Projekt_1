using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Shapes;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using InputValidationLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Services
{
    public static class CalculationServices
    {
        public static ICalculation? CreateMathCalculation(MathContext mathStrategy)
        {
            double[]? numbers = UserInputValidation.ReturnTwoNumbers("Enter two numbers: ");
            if (numbers == null) { return null; }
            ICalculation calculation = new MathCalculation
            {
                FirstInput = numbers[0],
                SecondInput = numbers[1],
                Answer = mathStrategy.ExecuteStrategy(numbers[0], numbers[1]),
                Operator = mathStrategy.Operator,
                Result = new Result
                {
                    ResultType = ResultTypes.MathCalculation.ToString(),
                }
            };
            return calculation;
        }

        public static ICalculation? CreateAreaCalculation(AreaCalculatorContext areaContext)
        {
            double[]? numbers = UserInputValidation.ReturnTwoNumbers("Enter two numbers: ");
            if (numbers == null) { return null; }

            ICalculation calculation = new AreaCalculation
            {
                Area = areaContext.ExecuteStrategy(numbers[0], numbers[1]).area,
                Circumference = areaContext.ExecuteStrategy(numbers[0], numbers[1]).circumference,
                Width = numbers[0],
                Height = numbers[1],
                ShapeName = areaContext.ShapeName,
                Result = new Result
                {
                    ResultType = ResultTypes.AreaCalculation.ToString(),
                }
            };
            return calculation;
        }
    }
}