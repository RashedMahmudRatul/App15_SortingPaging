﻿using System;
using System.Collections.Generic;

namespace App13_EFCoreDBFirst.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeStatus { get; set; }
        public decimal Salary { get; set; }
        public string PayBasis { get; set; }
        public string PositionTitle { get; set; }
    }
}
