
namespace PayrollBenefits.Models
{
    public class DefaultSalary : Salary
    {
        public override Money Amount => new Money(2000);
    }
}
