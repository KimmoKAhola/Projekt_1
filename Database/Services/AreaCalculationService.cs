using Calculations.StrategyContexts;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using InputValidationLibrary;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Database.Services
{
    public class AreaCalculationService(AreaCalculationRepository areaCalculationRepository, AreaCalculatorContext context) : IDatabaseService<AreaCalculation>
    {
        private readonly AreaCalculationRepository _areaCalculationRepository = areaCalculationRepository;
        private readonly AreaCalculatorContext _context = context;
        public void AddCalculation(AreaCalculation calculation)
        {
            _areaCalculationRepository.Add(calculation);
            _areaCalculationRepository.Save();
            PrintMessages.PrintSuccessMessage($"Added {calculation} to the database.");
        }

        public void DeleteCalculation(int id)
        {
            _areaCalculationRepository.SoftDelete(id);
            _areaCalculationRepository.Save();
        }

        public void ReadAllCalculations()
        {
            foreach (var item in _areaCalculationRepository.GetAll().ToList())
            {
                _context.SetStrategy(item.ShapeName.ToString());
                var (area, circumference) = _context.ExecuteStrategy(item.Width, item.Height);
                Console.WriteLine($"{item} + area {area} + circumference {circumference}");
            }
        }

        public List<AreaCalculation> GetAllCalculations()
        {
            return _areaCalculationRepository.GetAll().ToList();
        }

        public void ReadCalculation(int id)
        {
            var entity = _areaCalculationRepository.Get(id);
            Console.WriteLine(entity);
        }

        public void UpdateCalculation(int id)
        {
            AreaCalculation? entityToUpdate = _areaCalculationRepository.Get(id);
            var chosenProperty = PromptUpdate();
            if (entityToUpdate != null)
            {
                ChangeOption(chosenProperty, entityToUpdate);
                _areaCalculationRepository.Update(entityToUpdate);
                _areaCalculationRepository.Save();
            }
            else
            {
                PrintMessages.PrintErrorMessage("No entity with that ID was found.");
            }
        }

        private void ChangeOption(int? choice, AreaCalculation entity)
        {
            switch (choice - 1)
            {
                case 0:
                    UpdateWidth(entity);
                    break;
                case 1:
                    UpdateHeight(entity);
                    break;
                case 2:
                    UpdateShape(entity);
                    break;
                case 3:
                    DeleteCalculation(entity.Id);
                    break;
                case 4:
                    break;
            }
        }

        private static int? PromptUpdate()
        {
            Dictionary<int, string> options = new()
            {
                {1, "Width" },
                {2, "Height" },
                {3, "Shape" },
                {4, "Delete" },
            };
            return UserInputValidation.MenuValidation(options, "Bajs 123456");
        }

        private static void UpdateWidth(AreaCalculation entity)
        {
            Console.Write("Enter the new width: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                entity.Width = result;
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private static void UpdateHeight(AreaCalculation entity)
        {
            Console.Write("Enter the new height: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                entity.Height = result;
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private static void UpdateShape(AreaCalculation entity)
        {
            var listOfShapeNames = GetShapeNames();
            int? userChoice = UserInputValidation.MenuValidation(listOfShapeNames, "These are the available shapes to choose from.\n");
            if (userChoice != null)
            {
                entity.ShapeName = listOfShapeNames[(int)userChoice - 1];
            }
            else
            {
                Console.WriteLine("ERRORRR");
            }
            Console.ReadKey();
        }

        public static ICalculation? CreateAreaCalculation(AreaCalculatorContext areaContext)
        {
            PrintMessages.PrintNotification($"You chose {areaContext.ShapeName}.");
            double[]? numbers = UserInputValidation.ReturnTwoNumbers("Enter two positive numbers for width and height, separated by a space: ");
            if (numbers == null) { return null; }

            ICalculation calculation = new AreaCalculation
            {
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

        private static List<string> GetShapeNames()
        {
            var shapeInterfaceType = typeof(IShape);
            var shapeTypes = Assembly.GetAssembly(typeof(IShape)).GetTypes()
                .Where(t => shapeInterfaceType.IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            var shapeNames = shapeTypes.Select(t => (IShape)Activator.CreateInstance(t)).Select(s => s.Name).ToList();

            return shapeNames;
        }
    }
}
