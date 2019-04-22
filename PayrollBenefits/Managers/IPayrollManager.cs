using PayrollBenefits.Models;
using PayrollBenefits.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Managers
{
    public interface IPayrollManager
    {
        Money ComputeBenefitCost(Employee employee);
    }
}
