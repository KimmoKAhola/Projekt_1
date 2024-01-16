using Calculations.StrategyContexts;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Database.Interfaces;
using Database.Migrations;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Database.Services
{
    public class ShapeCalculatorService(ShapeCalculatorRepository areaCalculationRepository, ShapeContext context) : IDatabaseService<ShapeCalculation>
    {
        private readonly ShapeCalculatorRepository _areaCalculationRepository = areaCalculationRepository;
        private readonly ShapeContext _context = context;
        public void AddCalculation(ShapeCalculation calculation)
        {
            _areaCalculationRepository.Add(calculation);
            _areaCalculationRepository.Save();
            PrintMessages.PrintSuccessMessage("Save to database was successful.");
        }

        public void DeleteCalculation(int id)
        {
            _areaCalculationRepository.SoftDelete(id);
            _areaCalculationRepository.Save();
            PrintMessages.PrintNotification("Deletion was successful.");
        }

        public void ViewAllCalculations()
        {
            PrintShapeTable(_areaCalculationRepository.GetAll().ToList());
        }

        public List<ShapeCalculation> GetAllCalculations()
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
            ShapeCalculation? entityToUpdate = _areaCalculationRepository.Get(id);
            Console.WriteLine("These are the properties you can update for your chosen entity:");
            PrintMessages.PrintNotification($"\n{entityToUpdate}\n");
            var chosenProperty = PromptUpdate();
            if (entityToUpdate != null)
            {
                ChangeOption(chosenProperty, entityToUpdate);
                _areaCalculationRepository.Update(entityToUpdate);
                entityToUpdate.DateLastUpdated = DateTime.Now;
                _areaCalculationRepository.Save();
                PrintMessages.PrintSuccessMessage("Update was successful.");
            }
            else
            {
                PrintMessages.PrintErrorMessage("No entity with that ID was found.");
            }
        }

        private void ChangeOption(int? choice, ShapeCalculation entity)
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
                {1, "Update Width" },
                {2, "Update Height" },
                {3, "Update Shape" },
                {4, "Delete Calculation" },
            };
            return UserInputValidation.MenuValidation(options, "\n");
        }

        private static void UpdateWidth(ShapeCalculation entity)
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

        private static void UpdateHeight(ShapeCalculation entity)
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

        private static void UpdateShape(ShapeCalculation entity)
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

        public static ICalculation? CreateAreaCalculation(ShapeContext shapeContext)
        {
            PrintMessages.PrintNotification($"You chose {shapeContext.ShapeName}.");
            double[]? userInput = UserInputValidation.ReturnTwoNumbersForShapes("Enter two positive numbers for width and height, separated by a space: ");
            if (userInput == null) { return null; }

            ICalculation calculation = new ShapeCalculation
            {
                Width = userInput[0],
                Height = userInput[1],
                ShapeName = shapeContext.ShapeName,
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

        public void PrintShapeTable(IEnumerable<ShapeCalculation> allShapes)
        {
            if (allShapes == null || !allShapes.Any())
            {
                Console.WriteLine("No shapes to display.");
                return;
            }

            string idHeader = "Id";
            string shapeHeader = "Shape";
            string widthHeader = "Width";
            string heightHeader = "Height";
            string areaHeader = "Area";
            string circumferenceHeader = "Circumference";

            int idColumnWidth = Math.Max(allShapes.Max(r => r.Id.ToString().Length), idHeader.Length);
            int shapeColumnWidth = Math.Max(allShapes.Max(r => r.ShapeName.Length), shapeHeader.Length);
            int widthColumnWidth = Math.Max(allShapes.Max(r => r.Width.ToString().Length), widthHeader.Length) + 2;
            int heightColumnWidth = Math.Max(allShapes.Max(r => r.Height.ToString().Length), heightHeader.Length) + 2;
            int areaColumnWidth = 20;
            int circumferenceColumnWidth = 20;
            int totalWidth = $"{idHeader} | {shapeHeader} | {widthHeader} | {heightHeader} | {areaHeader} | {circumferenceHeader}".Length + areaColumnWidth + circumferenceColumnWidth;

            Console.WriteLine($"{idHeader.PadRight(idColumnWidth)} | {shapeHeader.PadRight(shapeColumnWidth)} | {widthHeader.PadRight(widthColumnWidth)}  | {heightHeader.PadRight(heightColumnWidth)}  | {areaHeader.PadRight(areaColumnWidth)}   | {circumferenceHeader.PadRight(circumferenceColumnWidth)}");
            Console.WriteLine(new string('-', totalWidth));
            foreach (var shape in allShapes)
            {
                _context.SetStrategy(shape.ShapeName.ToString());
                var (area, circumference) = _context.ExecuteStrategy(shape.Width, shape.Height);
                Console.WriteLine($"{shape.Id.ToString().PadRight(idColumnWidth)} | {shape.ShapeName.PadRight(shapeColumnWidth)} | {shape.Width.ToString().PadRight(widthColumnWidth) + "m"} | {shape.Height.ToString().PadRight(heightColumnWidth) + "m"} | {area.ToString().PadRight(areaColumnWidth) + "m²"} | {circumference.ToString().PadRight(circumferenceColumnWidth) + "m"}");
            }
            Console.WriteLine();
        }
    }
}
