using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollBenefits.Models.Employees
{
    public class Employee
    {
        public Employee()
        {
            Dependents = new  List<Dependent>();
            Salary = new DefaultSalary();
        }

        public Employee(string firstname, string lastname)
        :this()
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddDependent(Dependent dependent)
        {
            Dependents.Add(dependent);
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public Money BenefitCost { get; set; }

        [NotMapped]
        public Salary Salary { get; set; }

        public  ICollection<Dependent> Dependents { get; set; }
    }
}
