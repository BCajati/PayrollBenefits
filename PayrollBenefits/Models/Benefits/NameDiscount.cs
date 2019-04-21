using PayrollBenefits.Models.Employees;
using System.Collections.Generic;

namespace PayrollBenefits.Models.Benefits
{
    public class NameDiscount : IDiscount
    {
        // to do inject values
        private readonly string discountCharacters = "A";
        private readonly decimal employeeDiscount = 0.10M;
        private readonly decimal dependentDiscount = 0.10M;
        private readonly decimal noDiscount = 0M;

        public NameDiscount()
        {

        }

        public Discount FindAllDiscounts(Employee employee)
        {
            var discount = new Discount();
            discount.EmployeeDiscount = FindEmployeeDiscount(employee);
            discount.DependentDiscounts.AddRange(FindDependentDiscounts(employee));

            return discount;
        }

        public decimal FindEmployeeDiscount(Employee employee)
        {

            if (employee.FirstName.StartsWith(discountCharacters) || employee.LastName.StartsWith(discountCharacters))
                return employeeDiscount;

            return noDiscount;
        }

        public List<decimal> FindDependentDiscounts(Employee employee)
        {
            var discounts = new List<decimal>();

            foreach (var dep in employee.Dependents)
            {
                if (dep.FirstName.StartsWith(discountCharacters) || dep.LastName.StartsWith(discountCharacters))
                    discounts.Add(dependentDiscount);
            }
            return discounts;
        }
    }
}
