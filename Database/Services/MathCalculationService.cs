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
            _calculationRepository.Add(calculation);
            _calculationRepository.Save();
            PrintMessages.PrintSuccessMessage($"{calculation} has been added to the system.");
        }

        public void DeleteCalculation(MathCalculation calculation)
        {
            _calculationRepository.SoftDelete(calculation.Id);
            _calculationRepository.Save();
            PrintMessages.PrintNotification($"{calculation} has been deleted.");
        }

        public void ReadAllCalculations(MathCalculation calculation)
        {
            _calculationRepository.GetAll().ToList().ForEach(Console.WriteLine);
        }

        public void ReadCalculation(MathCalculation calculation)
        {
            throw new NotImplementedException();
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

        public static List<char> Bajskorv()
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
