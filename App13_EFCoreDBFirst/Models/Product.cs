using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App13_EFCoreDBFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Double Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdateOn { get; set; }
        public Category Category { get; set; }









    }
}
