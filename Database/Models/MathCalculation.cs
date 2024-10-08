﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interfaces;

namespace Database.Models
{
    public class MathCalculation : IEntity
    {
        public int Id { get; set; }
        [Required]
        public char Operator { get; set; }

        public double Answer { get; set; }

        public double FirstInput { get; set; }
        public double SecondInput { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateLastUpdated { get; set; }

        public override string ToString()
        {
            if (Operator != '√')
            {
                return $"\tId{Id,3}: {FirstInput} {Operator} {SecondInput,2} = {Answer,-5}";
            }
            else
            {
                return $"\tId{Id,3}: {FirstInput}^(1/{SecondInput}) = {Answer,-5}";
            }
        }
    }
}
