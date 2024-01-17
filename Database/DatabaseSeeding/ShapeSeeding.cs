using Calculator.Shapes;
using Database.DatabaseConfiguration;
using Database.Models;
using Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DatabaseSeeding
{
    public class ShapeSeeding(ShapeCalculatorService service)
    {
        private readonly ShapeCalculatorService _service = service;
        public void SeedData()
        {
            var rectangle = new Rectangle
            {
                Width = 10,
                Height = 10,
            };
            var triangle = new Triangle
            {
                Width = 15,
                Height = 25,
            };
            var rhomboid = new Rhomboid
            {
                Width = 25,
                Height = 25,
            };
            var parallelogram = new Parallelogram
            {
                Width = 13,
                Height = 23,
            };
            List<ShapeCalculation> calculations = new()
            {
                new ShapeCalculation
                {
                    Width = rectangle.Width,
                    Height = rectangle.Height,
                    ShapeName = rectangle.Name
                },
                new ShapeCalculation
                {
                    Width = triangle.Width,
                    Height = triangle.Height,
                    ShapeName = triangle.Name
                },
                new ShapeCalculation
                {
                    Width = rhomboid.Width,
                    Height = rhomboid.Height,
                    ShapeName = rhomboid.Name
                },
                new ShapeCalculation
                {
                    Width = parallelogram.Width,
                    Height = parallelogram.Height,
                    ShapeName = parallelogram.Name
                },
            };
            foreach (var calculation in calculations)
            {
                _service.AddCalculation(calculation);
            }
        }
    }
}