﻿using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using InputValidationLibrary;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class DatabaseService(DatabaseContext context) : IDatabaseService
    {
        private DatabaseContext DbContext { get; set; } = context;

        public void AddCalculation(ICalculation calculation)
        {
            if (calculation is MathCalculation)
            {
                var temp = (MathCalculation)calculation;
                DbContext.Calculation.Add(temp);
                PrintMessages.PrintSuccessMessage($"{temp} has been added to the system.");
            }
            else
            {
                var temp = (AreaCalculation)calculation;
                DbContext.AreaCalculation.Add(temp);
                PrintMessages.PrintSuccessMessage($"{temp} has been added to the system.");
            }
            DbContext.SaveChanges();
        }

        public void DeleteCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void ReadAllCalculations(ICalculation calculation)
        {
            List<ICalculation> temp;
            if (calculation is MathCalculation)
            {
                temp = DbContext.Calculation.OfType<MathCalculation>().Cast<ICalculation>().ToList();
            }
            else
            {
                temp = DbContext.AreaCalculation.OfType<AreaCalculation>().Cast<ICalculation>().ToList();
            }
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            PrintMessages.PressAnyKeyToContinue();
        }

        public void ReadCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void UpdateCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }
        public void AddRockPaperScissorsHighScore(Game game)
        {
            throw new NotImplementedException();
        }

        public void AddRockPaperScissorsResult(Game game)
        {
            var rps = new RockPaperScissors
            {
                PlayerMove = game.PlayerMove,
                ComputerMove = game.ComputerMove,
                Outcome = game.Outcome,
                Result = new Result
                {
                    ResultType = ResultTypes.RockPapperScissors.ToString(),
                }
            };
            DbContext.Add(rps);
            DbContext.SaveChanges();
        }
    }
}
