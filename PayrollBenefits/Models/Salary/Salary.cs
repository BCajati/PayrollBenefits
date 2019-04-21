using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Models
{
    public abstract class Salary
    {

        public Salary()
        {
            // timeschedule is fixed for all salary types
            PayrollSchedule = TimeSpan.FromDays(14);
        }

        public abstract Money Amount { get; }


        public TimeSpan PayrollSchedule { get; }
    }
}
