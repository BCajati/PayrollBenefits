using System;
using System.Collections.Generic;

namespace PayrollBenefits.Models.Benefits
{
    public class Discount
    {
        public Discount()
        {
            DependentDiscounts = new List<decimal>();
        }

        public decimal EmployeeDiscount { get; set; }

        public List<decimal> DependentDiscounts { get; set; }
    }
}
