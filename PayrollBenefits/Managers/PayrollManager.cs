using PayrollBenefits.Models.Employees;
using PayrollBenefits.Models;
using PayrollBenefits.Models.Benefits;
using System.Collections.Generic;

namespace PayrollBenefits.Managers
{
    public class PayrollManager : IPayrollManager
    {
        private Benefit defaultBenefit;
        private IBenefitCalculator calculator;
        const int WeeksPerYear = 52;

        public PayrollManager()
        {
            // in a production app, these would come from an API or database
            defaultBenefit = new Benefit();
            var nameDiscount = new NameDiscount();
            calculator = new BenefitCalculator(new List<IDiscount>() { nameDiscount });
        }

        public void SetEmployeeBenefits(Employee employee)
        {
            employee.BenefitCost = ComputeBenefitCost(employee);
            employee.YearlySalary = GetYearlySalary(employee);
        }

        public Money GetYearlySalary(Employee employee)
        {
            var salary = new DefaultSalary();
            var payPeriodsPerYear = WeeksPerYear / salary.WeeksPerPayPeriod;
            return salary.Amount * payPeriodsPerYear;
            
        }

        public Money ComputeBenefitCost(Employee employee)
        {
            var samplePayroll = new Payroll() { Benefit = defaultBenefit, Employee = employee };

            return calculator.ComputeBenefitCostPerYear(samplePayroll);
        }

    }
}
