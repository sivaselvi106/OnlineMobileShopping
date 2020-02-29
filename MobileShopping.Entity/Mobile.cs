using System;
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
        public int Id { get; set; }
        [Required]
        public string MobileModel { get; set; }
        [Required]
      
        public string Color { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
