using PayrollBenefits.Models;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Managers
{
    public interface IPayrollManager
    {
        Money ComputeBenefitCost(Employee employee);

        void SetEmployeeBenefits(Employee employee);

        Money GetYearlySalary(Employee employee);

    }
}
