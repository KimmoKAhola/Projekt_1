﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interfaces;

namespace Database.Models
{
    public class MathCalculation : ICalculation
    {
        public int Id { get; set; }
        [Required]
        public char Operator { get; set; }

        public double Answer { get; set; }

        public double FirstInput { get; set; }
        public double SecondInput { get; set; }

        [Required]
        public Result Result { get; set; } = null!;

        public override string ToString()
        {
            if (Operator != '√')
            {
                return $"{FirstInput} {Operator} {SecondInput} = {Answer}";
            }
            else
            {
                return $"{Operator}{FirstInput} = {Answer}";
            }
        }
    }
}
