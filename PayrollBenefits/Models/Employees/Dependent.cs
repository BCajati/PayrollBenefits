using System;
using System.Collections.Generic;
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

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Relationship { get; set; }
    }
}
