using System;

namespace Expense.Data
{
    public class ExpenseCatagory : AbstractEntity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }
        public decimal MonthlyAllocation { get; set; }
        public ExpenseCatagory() : base(nameof(ExpenseCatagory)) { }
    }
}