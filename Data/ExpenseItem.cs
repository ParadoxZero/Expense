using System;

namespace Expense.Data
{
    public class ExpenseItem : AbstractEntity
    {
        public Guid UserId { get; set; }
        public Guid CategoryID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ExpenseItem() : base(nameof(ExpenseItem)) { }
    }
}