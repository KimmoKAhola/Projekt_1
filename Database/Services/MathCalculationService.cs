using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using InputValidationLibrary;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Database.Services
{
    public class MathCalculationService(CalculationRepository calculationRepository) : IDatabaseService<MathCalculation>
    {
        private readonly CalculationRepository _calculationRepository = calculationRepository;
        public void AddCalculation(MathCalculation calculation)
        {
            _calculationRepository.Add(calculation);
            _calculationRepository.Save();
            PrintMessages.PrintSuccessMessage($"{calculation} has been added to the system.");
        }

        public void DeleteCalculation(MathCalculation calculation)
        {
            _calculationRepository.Delete(calculation.Id);
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

        public void UpdateCalculation(MathCalculation calculation)
        {
            _calculationRepository.Update(calculation);
            _calculationRepository.Save();
            PrintMessages.PrintNotification($"{calculation} has been updated.");
        }
    }
}
