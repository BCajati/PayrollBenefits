namespace PayrollBenefits.Models.Benefits
{
    public class Benefit
    {
        public Benefit() :this(1000, 500)
        {
        }

        public Benefit(decimal employeeCost, decimal dependentCost)
        {
            EmployeeCost = new Money(employeeCost);
            CostPerDependent = new Money(dependentCost);
        }
        public Money EmployeeCost { get; set; }

        public Money CostPerDependent { get; set; }
    }
}
