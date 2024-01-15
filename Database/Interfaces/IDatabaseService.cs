﻿using Rock_Paper_Scissors;

namespace Database.Interfaces
{
    public interface IDatabaseService<T> where T : class
    {
        void AddCalculation(T calculation);
        void ReadCalculation(T calculation);
        void ReadAllCalculations(T calculation);
        void UpdateCalculation(T calculation);
        void DeleteCalculation(T calculation);
    }
}