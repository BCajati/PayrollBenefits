using PayrollBenefits.Models;
using PayrollBenefits.Models.Benefits;
using System.Collections.Generic;
using System.Linq;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Managers
{
    public class BenefitCalculator : IBenefitCalculator
    {
        private List<Models.Benefits.IDiscount> benefitDiscounts = new  List<IDiscount>();

        public BenefitCalculator(List<IDiscount>discounts)
        {
            benefitDiscounts.AddRange(discounts);
        }

        public Money ComputeBenefitCostPerYear(Payroll payroll)
        {
            var employeeAmount = employeeCost(payroll.Employee, payroll.Benefit.EmployeeCost);
            var dependentAmount = dependentCost(payroll.Employee, payroll.Benefit.CostPerDependent);

            return employeeAmount + dependentAmount;
        }

        public Money employeeCost(Employee employee, Money employeeCost)
        {
            // search for discounts
            var employeeDiscount = benefitDiscounts.Select(x => x.FindEmployeeDiscount(employee)).Sum();

            var discountAmount = employeeDiscount.Equals(0) ? 0 : employeeCost * employeeDiscount;
            return employeeCost - discountAmount;
        }

        public Money dependentCost(Employee employee, Money dependentCost)
        {
            if (employee.Dependents.Count.Equals(0))
                return 0M;

            var discountAmount = 0M;
            var totalDependentCost = dependentCost * employee.Dependents.Count;
            var listOfDependentDiscounts = new List<decimal>();

            // apply each benefit to each eligible dependent
            // right now all dependents are the same,
            // so we are not distinguishing which one, just how many get a discount
            foreach (var dependentDiscounts in benefitDiscounts)
            {
                var discount = dependentDiscounts.FindDependentDiscounts(employee);
                discountAmount = discount.Select(x => x * dependentCost.Amount).Sum();
            }
            return totalDependentCost - discountAmount;

        }
    }
}
