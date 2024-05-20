using System.Collections.Generic;
using ExpenseManagerApp.Model.Split;

namespace ExpenseManagerApp.Model.Expense
{
    public class EqualExpense : Expense
    {
        public EqualExpense(double amount, User paidBy, List<Split.Split> splits) : base(amount, paidBy, splits)
        {
        }

        public override bool Validate()
        {
            foreach (var split in Splits)
            {
                if (!(split is EqualSplit))
                    return false;
            }

            return true;
        }
    }
}

