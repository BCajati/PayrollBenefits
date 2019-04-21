using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollBenefits.Managers;
using PayrollBenefits.Models;
using PayrollBenefits.Models.Benefits;
using PayrollBenefits.Models.Employees;

namespace PayrollBenefits.Test.Managers
{
    [TestClass]
    public class BenefitCalculatorTest
    {
        private BenefitCalculator calculator;
        private Benefit defaultBenefit = new Benefit();
        // these should be configurable - inject into test as well as into solution
        private readonly decimal employeeBenefitCost = 1000M;
        private readonly decimal dependentBenefitCost = 500M;
        private readonly decimal discount = .10M;


        [TestInitialize]
        public void Setup()
        {
            var nameDiscount = new NameDiscount();
            calculator = new BenefitCalculator(new List<IDiscount>(){nameDiscount});
        }

        [TestMethod]
        public void EmployeeWithNoDependentsAndNoDiscount()
        {
            var employee = new Employee("Kate", "Janeway");
            var samplePayroll = new Payroll() {Benefit = defaultBenefit, Employee = employee};

            var benefitCost = calculator.ComputeBenefitCostPerYear(samplePayroll);
            Assert.AreEqual(employeeBenefitCost, benefitCost);
        }

        [TestMethod]
        public void EmployeeWithNoDependentsAndNameDiscount()
        {
            // setup
            var employee = new Employee("Alan", "Shephard");
            var defaultBenefit = new Benefit(); 
            var samplePayroll = new Payroll() { Benefit = defaultBenefit, Employee = employee };

            // execute
            var benefitCost = calculator.ComputeBenefitCostPerYear(samplePayroll);

            //assert
            Assert.AreEqual(employeeBenefitCost - (employeeBenefitCost * discount), benefitCost);
        }

        [TestMethod]
        public void EmployeeWithDependentDiscount()
        {
            //setup
            var employee = new Employee("Commander", "Worf");
            employee.AddDependent(new Dependent("Alexander", "Worf", "child"));

            var samplePayroll = new Payroll() { Benefit = defaultBenefit, Employee = employee };

            // execute
            var benefitCost = calculator.ComputeBenefitCostPerYear(samplePayroll);

            //assert
            var expectedcost = employeeBenefitCost + dependentBenefitCost - (dependentBenefitCost * discount);
            Assert.AreEqual(expectedcost, benefitCost);
        }

        [TestMethod]
        public void EmployeeWithTwoDependentsAndNoDiscount()
        {
            //setup
            var employee = new Employee("Deanna", "Troi");
            employee.AddDependent(new Dependent("Daughter1","Troi","child"));
            employee.AddDependent(new Dependent("Son1", "Troi", "child"));

            var samplePayroll = new Payroll() { Benefit = defaultBenefit, Employee = employee };

            // execute
            var benefitCost = calculator.ComputeBenefitCostPerYear(samplePayroll);

            //assert
            Assert.AreEqual(employeeBenefitCost + (dependentBenefitCost * 2), benefitCost);
        }

        [TestMethod]
        public void EmployeeWithAllDiscounts()
        {
            //setup
            var employee = new Employee("Alyssa", "Ogawa");
            employee.AddDependent(new Dependent("Amy", "Ogawa", "child"));
            employee.AddDependent(new Dependent("Andrew", "Ogawa", "child"));

            var samplePayroll = new Payroll() { Benefit = defaultBenefit, Employee = employee };

            // execute
            var benefitCost = calculator.ComputeBenefitCostPerYear(samplePayroll);

            //assert
            var expectedEmployeeCost = employeeBenefitCost - (employeeBenefitCost * discount);
            var expectedDependentCost = dependentBenefitCost - (dependentBenefitCost * discount);
            Assert.AreEqual(expectedEmployeeCost + (expectedDependentCost * 2), benefitCost);
        }
    }
}
