using PayrollBenefits.Models.Employees;
using Microsoft.EntityFrameworkCore;


namespace PayrollBenefits.DataLayer
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions<PayrollContext> options)
       : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Dependent> Dependents { get; set; }

    }
}
