using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App13_EFCoreDBFirst.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateOn { get; set; }


    }
}
