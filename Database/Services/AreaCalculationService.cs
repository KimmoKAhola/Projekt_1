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
    public class AreaCalculationService(AreaCalculationRepository areaCalculationRepository) : IDatabaseService<AreaCalculation>
    {
        private readonly AreaCalculationRepository _areaCalculationRepository = areaCalculationRepository;
        public void AddCalculation(AreaCalculation calculation)
        {
            _areaCalculationRepository.Add(calculation);
            _areaCalculationRepository.Save();
            PrintMessages.PrintSuccessMessage($"Added {calculation} to the database.");
        }

        public void DeleteCalculation(AreaCalculation calculation)
        {
            _areaCalculationRepository.Delete(calculation.Id);
            _areaCalculationRepository.Save();
        }

        public void ReadAllCalculations(AreaCalculation calculation)
        {
            _areaCalculationRepository.GetAll().ToList().ForEach(Console.WriteLine);
        }

        public void ReadCalculation(AreaCalculation calculation)
        {
            //return _areaCalculationRepository.Get(calculation.Id);
        }

        public void UpdateCalculation(AreaCalculation calculation)
        {
            _areaCalculationRepository.Update(calculation);
            _areaCalculationRepository.Save();
        }
    }
}
