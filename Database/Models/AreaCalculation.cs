﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Interfaces;

namespace Database.Models
{
    public class AreaCalculation : ICalculation, IDatabaseEntity
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsDeleted { get; set; } = false;

        [Required]
        public string ShapeName { get; set; } = null!;

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateLastUpdated { get; set; }

        public override string ToString()
        {
            return $"Id [{Id}] - {ShapeName}\tWidth: {Width}\tHeight: {Height}";
        }
    }
}
