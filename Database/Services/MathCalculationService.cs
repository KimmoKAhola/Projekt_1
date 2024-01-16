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
    public class MathCalculationService(CalculationRepository calculationRepository, MathContext context) : IDatabaseService<MathCalculation>
    {
        private readonly CalculationRepository _calculationRepository = calculationRepository;
        private readonly MathContext _context = context;
        public void AddCalculation(MathCalculation calculation)
        {
            if (!double.IsNaN(calculation.Answer))
            {
                _calculationRepository.Add(calculation);
                _calculationRepository.Save();
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
        }

        public void ReadAllCalculations()
        {
            _calculationRepository.GetAll().ToList().ForEach(Console.WriteLine);
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
                entity.SecondInput = result;
            }
            else
            {
                PrintMessages.PrintErrorMessage("Incorrect input.");
            }
        }


        private static void UpdateOperator(MathCalculation entity)
        {
            Console.Clear();
            var listOfOperators = GetMathOperators();
            int? choice = UserInputValidation.MenuValidation(listOfOperators, "HEJ HOPP");
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
            return UserInputValidation.MenuValidation(options, "TEMPORARY");
        }
        public static ICalculation? CreateMathCalculation(MathContext mathStrategy)
        {
            double[]? numbers = UserInputValidation.ReturnTwoNumbersForMath("Enter two numbers: ");
            if (numbers == null) { return null; }
            ICalculation calculation = new MathCalculation
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
            var shapeInterfaceType = typeof(IMathStrategy);
            var shapeTypes = Assembly.GetAssembly(typeof(IMathStrategy)).GetTypes()
                .Where(t => shapeInterfaceType.IsAssignableFrom(t) && !t.IsInterface)
                .ToList();

            var operatorNames = shapeTypes.Select(t => (IMathStrategy)Activator.CreateInstance(t)).Select(s => s.Operator).ToList();

            return operatorNames;
        }
    }
}
