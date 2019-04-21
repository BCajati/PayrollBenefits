using System.Collections.Generic;

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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Salary Salary { get; set; }

        public List<Dependent> Dependents { get; set; }
    }
}
