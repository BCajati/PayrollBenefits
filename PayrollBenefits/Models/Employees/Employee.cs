using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Yearly Benefit Cost")]
        public Money BenefitCost { get; set; }

        [NotMapped]
        [DisplayName("Salary")]
        public Salary Salary { get; set; }

        public  ICollection<Dependent> Dependents { get; set; }
    }
}
