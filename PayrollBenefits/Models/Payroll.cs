using PayrollBenefits.Models.Benefits;
using PayrollBenefits.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Models
{
    public class Payroll
    {
        public Employee Employee { get; set; }

        public Benefit Benefit { get; set; }
    }
}
