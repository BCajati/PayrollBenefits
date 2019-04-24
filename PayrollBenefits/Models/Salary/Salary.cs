namespace PayrollBenefits.Models
{
    public abstract class Salary
    {

        public Salary()
        {
            // timeschedule is fixed for all salary types
            WeeksPerPayPeriod = 2;
        }

        public abstract Money Amount { get; }


        public int WeeksPerPayPeriod { get; }
    }
}
