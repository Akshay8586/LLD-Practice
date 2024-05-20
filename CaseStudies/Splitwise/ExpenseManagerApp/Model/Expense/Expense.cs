using System.Collections.Generic;

namespace ExpenseManagerApp.Model.Expense
{
    public abstract class Expense
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public User PaidBy { get; set; }
        public List<Split.Split> Splits { get; set; }

        public Expense(double amount, User paidBy, List<Split.Split> splits)
        {
            Amount = amount;
            PaidBy = paidBy;
            Splits = splits;
        }

        public abstract bool Validate();
    }
}