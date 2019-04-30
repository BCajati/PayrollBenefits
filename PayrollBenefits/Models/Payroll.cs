using PayrollBenefits.Models.Benefits;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Models
{
    public class Payroll
    {
        public Employee Employee { get; set; }

        public Benefit Benefit { get; set; }
    }
}
