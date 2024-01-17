using Calculations.StrategyContexts;
using Calculator.Interfaces;
using Database.DatabaseConfiguration;
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
    public class CalculatorService(CalculatorRepository calculationRepository, CalculatorContext context) : IDatabaseService<MathCalculation>
    {
        private readonly CalculatorRepository _calculationRepository = calculationRepository;
        private readonly CalculatorContext _context = context;
        public void AddCalculation(MathCalculation calculation)
        {
            if (!double.IsNaN(calculation.Answer))
            {
                _calculationRepository.Add(calculation);
                _calculationRepository.Save();
                Console.Clear();
                Console.WriteLine($"Your calculation: {calculation.FirstInput} {calculation.Operator} {calculation.SecondInput} = {calculation.Answer}");
                PrintMessages.PrintSuccessMessage("Save to database was successful.");
            }
            else
            {
                PrintMessages.PrintErrorMessage("Invalid operation.");
            }
        }

        public void DeleteCalculation(int id)
        {
            _calculationRepository.SoftDelete(id);
            _calculationRepository.Save();
            PrintMessages.PrintNotification("Deletion was successful.");
        }

        public void ViewAllCalculations()
        {
            PrintMathTable(_calculationRepository.GetAll());
        }

        public List<MathCalculation> GetAllCalculations()
        {
            return _calculationRepository.GetAll().ToList();
        }

        public void ReadCalculation(int id)
        {
            var entity = _calculationRepository.Get(id);
            Console.WriteLine(entity);
        }

        public void UpdateCalculation(int id)
        {
            MathCalculation? entityToUpdate = _calculationRepository.Get(id);
            Console.WriteLine("These are the properties you can update for your chosen entity:");
            PrintMessages.PrintNotification($"\n{entityToUpdate}\n");
            int? chosenProperty = PromptUpdate();
            if (entityToUpdate != null)
            {
                ChangeOption(chosenProperty, entityToUpdate);
                _context.SetStrategy(entityToUpdate.Operator);
                entityToUpdate.Answer = _context.ExecuteStrategy(entityToUpdate.FirstInput, entityToUpdate.SecondInput);
                if (!double.IsNaN(entityToUpdate.Answer))
                {
                    _calculationRepository.Update(entityToUpdate);
                    entityToUpdate.DateLastUpdated = DateTime.Now;
                    _calculationRepository.Save();
                    PrintMessages.PrintSuccessMessage("The database has been updated.");
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid input for that operator.");
                }
            }
            else
            {
                PrintMessages.PrintErrorMessage("No entity with that id was found.");
            }
        }

        private void ChangeOption(int? choice, MathCalculation entity)
        {
            switch (choice - 1)
            {
                case 0:
                    UpdateFirstInput(entity);
                    break;
                case 1:
                    UpdateSecondInput(entity);
                    break;
                case 2:
                    UpdateOperator(entity);
                    break;
                case 3:
                    DeleteCalculation(entity.Id);
                    break;
            }
        }
        private static void UpdateFirstInput(MathCalculation entity)
        {
            Console.Write("Enter the new input: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                entity.FirstInput = result;
            }
            else
            {
                PrintMessages.PrintErrorMessage("Incorrect input.");
            }
        }
        private static void UpdateSecondInput(MathCalculation entity)
        {
            Console.Write("Enter the new input: ");
            if (double.TryParse(Console.ReadLine(), out double result))
            {
                if (entity.Operator == '√' && result <= 0)
                {
                    PrintMessages.PrintErrorMessage("The input has to be positive for the '√' operator.");
                }
                else
                {
                    entity.SecondInput = result;
                }
            }
            else
            {
                PrintMessages.PrintErrorMessage("Incorrect input.");
            }
        }


        private static void UpdateOperator(MathCalculation entity)
        {
            var listOfOperators = GetMathOperators();
            int? choice = UserInputValidation.MenuValidation(listOfOperators, "These are the operators you can choose from.\n");
            if (choice != null)
            {
                var op = listOfOperators[(int)choice - 1];
                entity.Operator = op;
            }
        }


        private static int? PromptUpdate()
        {
            Dictionary<int, string> options = new()
            {
                {1, "First input" },
                {2, "Second input" },
                {3, "Operator input" },
                {4, "Delete" },
            };
            return UserInputValidation.MenuValidation(options, "\n");
        }
        public static IEntity? CreateMathCalculation(CalculatorContext mathStrategy)
        {
            PrintMessages.PrintNotification($"You chose {mathStrategy.Operator}");
            double[]? numbers;
            if (mathStrategy.Operator == '√')
            {
                PrintMessages.PrintNotification("You are about to calculate the nth root of a number." +
                    "\nThe first number is the base and the second number is the inverse exponent." +
                    "\nExample: 5 3 gives: (5)^(1/3)" +
                    "\nand 4 2 gives: sqrt(4)");
                numbers = UserInputValidation.ReturnTwoNumbersForMath("Enter two numbers, separated by a space: ");
            }
            else
            {
                numbers = UserInputValidation.ReturnTwoNumbersForMath("Enter two numbers, separated by a space: ");
            }
            if (numbers == null) { return null; }
            IEntity calculation = new MathCalculation
            {
                FirstInput = numbers[0],
                SecondInput = numbers[1],
                Answer = mathStrategy.ExecuteStrategy(numbers[0], numbers[1]),
                Operator = mathStrategy.Operator,
            };
            return calculation;
        }

        public static List<char> GetMathOperators()
        {
            var shapeInterfaceType = typeof(IMath);
            var shapeTypes = Assembly.GetAssembly(typeof(IMath)).GetTypes()
                .Where(t => shapeInterfaceType.IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            var operatorNames = shapeTypes.Select(t => (IMath)Activator.CreateInstance(t)).Select(s => s.Operator).ToList();

            return operatorNames;
        }

        public void PrintMathTable(IEnumerable<MathCalculation> allCalculations)
        {
            if (allCalculations == null || !allCalculations.Any())
            {
                Console.WriteLine("No shapes to display.");
                return;
            }

            string idHeader = "Id";
            string firstHeader = "First";
            string operatorHeader = "Operator";
            string secondHeader = "Second";
            string answerHeader = "Answer";
            string dateHeader = "Date Created";
            string dateModifiedHeader = "Date Last Modified";

            int idColumnWidth = Math.Max(allCalculations.Max(r => r.Id.ToString().Length), idHeader.Length);
            int firstInputWidth = Math.Max(allCalculations.Max(r => r.FirstInput.ToString().Length), firstHeader.Length);
            int secondInputWidth = Math.Max(allCalculations.Max(r => r.SecondInput.ToString().Length), secondHeader.Length);
            int operatorInputWidth = Math.Max(allCalculations.Max(r => r.SecondInput.ToString().Length), operatorHeader.Length);
            int answerColumnWidth = Math.Max(allCalculations.Max(r => r.Answer.ToString().Length), answerHeader.Length);
            int dateColumnWidth = Math.Max(allCalculations.Max(r => r.DateCreated.ToString().Length), dateHeader.Length);
            int dateModifiedColumnWidth = Math.Max(allCalculations.Max(r => (r.DateLastUpdated?.ToString().Length) ?? 0), dateModifiedHeader.Length);
            int totalWidth = $"{idHeader} | {firstHeader} | {operatorHeader} | {secondHeader} | {answerHeader} | {dateHeader} | {dateModifiedHeader}".Length + 7;

            Console.WriteLine($"{idHeader.PadRight(idColumnWidth)} | {firstHeader.PadRight(firstInputWidth)} | {operatorHeader.PadRight(operatorInputWidth)} | {secondHeader.PadRight(secondInputWidth)} | {answerHeader.PadRight(answerColumnWidth)} | {dateHeader.PadRight(dateColumnWidth)} | {dateModifiedHeader.PadRight(dateModifiedColumnWidth)}");
            Console.WriteLine(new string('-', totalWidth));
            foreach (var calculation in allCalculations)
            {
                _context.SetStrategy(calculation.Operator);
                var answer = _context.ExecuteStrategy(calculation.FirstInput, calculation.SecondInput);
                Console.WriteLine($"{calculation.Id.ToString().PadRight(idColumnWidth)} | {calculation.FirstInput.ToString().PadRight(firstInputWidth)} | {calculation.Operator.ToString().PadRight(operatorInputWidth)} | {calculation.SecondInput.ToString().PadRight(secondInputWidth)} | {calculation.Answer.ToString().PadRight(answerColumnWidth)} | {calculation.DateCreated.ToString().PadRight(dateColumnWidth)} | {calculation.DateLastUpdated.ToString()?.PadRight(dateModifiedColumnWidth)}");
            }
            Console.WriteLine();
        }
    }
}
