using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollBenefits.Models.Employees
{
    public class Dependent
    {

        public Dependent()
        {
        }

        public Dependent(string firstname, string lastname, string relationship)
        {
            FirstName = firstname;
            LastName = lastname;
            Relationship = relationship;
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Relationship { get; set; }

        [NotMapped]
        public Money BenefitCost { get; set; }
    }
}
