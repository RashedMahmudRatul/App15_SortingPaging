using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App13_EFCoreDBFirst.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Dept { get; set; }
        public List<StudentCourse> StudentCourse { get; set; }




    }
}
