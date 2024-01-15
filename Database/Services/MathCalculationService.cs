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
            var calculation = _calculationRepository.Get(id);
            _calculationRepository.Update(calculation);
            _calculationRepository.Save();
            PrintMessages.PrintNotification($"{calculation} has been updated.");
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
                Result = new Result
                {
                    ResultType = ResultTypes.MathCalculation.ToString(),
                }
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
