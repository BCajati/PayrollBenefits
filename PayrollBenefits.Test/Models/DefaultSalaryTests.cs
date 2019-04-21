using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollBenefits.Models;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Test.Models
{
    [TestClass]
    public class DefaultSalaryTests
    {

        public void EmployeeGetsDefaultSalary()
        {
            var newEmployee = new Employee();
            var defaultSalary = new DefaultSalary();

            Assert.IsTrue(newEmployee.Dependents.Count == 0);
            Assert.AreEqual(defaultSalary.Amount, newEmployee.Salary.Amount, "salary");
            Assert.AreEqual(defaultSalary.PayrollSchedule, newEmployee.Salary.PayrollSchedule, "schedule");

        }
    }
}
