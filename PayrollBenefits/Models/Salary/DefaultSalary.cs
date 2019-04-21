using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Models
{
    public class DefaultSalary : Salary
    {
        public override Money Amount => new Money(2000);
    }
}
