﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MobileShopping.Entity
{
    public class Mobile
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string MobileModel { get; set; }
        [Required]
        public string Processor { get; set; }
        [Required]
        public byte RAM { get; set; }
        [Required]
        public int Storage { get; set; }
        [Required]
        public string DisplaySize { get; set; }
        [Required]
        public decimal Slimness { get; set; }
        [Required]
        public string Pixel { get; set; }
        [Required]
        public string BatteryCapacity { get; set; }
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
