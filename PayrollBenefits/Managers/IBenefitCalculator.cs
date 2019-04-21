using PayrollBenefits.Models;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Managers
{
    public interface IBenefitCalculator
    {
        Money ComputeBenefitCostPerYear(Payroll payroll);

        Money employeeCost(Employee employee, Money employeeCost);

        Money dependentCost(Employee employee, Money dependentCost);

    }
}
