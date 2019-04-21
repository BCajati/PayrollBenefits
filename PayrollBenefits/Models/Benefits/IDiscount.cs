using PayrollBenefits.Models.Employees;
using System.Collections.Generic;

namespace PayrollBenefits.Models.Benefits
{
    public interface IDiscount
    {
        Discount FindAllDiscounts(Employee employee);

        decimal FindEmployeeDiscount(Employee employee);

        List<decimal> FindDependentDiscounts(Employee employee);
    }
}
