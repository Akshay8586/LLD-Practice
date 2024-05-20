using System.Collections.Generic;
using ExpenseManagerApp.Model.Split;

namespace ExpenseManagerApp.Model.Expense
{
    public class ExactExpense : Expense
    {
        public ExactExpense(double amount, User paidBy, List<Split.Split> splits) : base(amount, paidBy, splits)
        {
        }

        public override bool Validate()
        {
            foreach (var split in Splits)
            {
                if (!(split is ExactSplit))
                    return false;
            }

            double totalAmount = 0;
            double sumSplitAmount = 0;

            foreach (var split in Splits)
            {
                if (split is ExactSplit exactSplit)
                    sumSplitAmount += exactSplit.GetAmount();
            }

            if (totalAmount != sumSplitAmount)
                return false;

            return true;
        }
    }
}

