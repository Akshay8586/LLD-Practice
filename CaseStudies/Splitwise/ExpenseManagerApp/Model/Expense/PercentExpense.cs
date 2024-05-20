using System.Collections.Generic;
using ExpenseManagerApp.Model.Split;

namespace ExpenseManagerApp.Model.Expense
{

    public class PercentExpense : Expense
    {
        public PercentExpense(double amount, User paidBy, List<Split.Split> splits) : base(amount, paidBy, splits)
        {
        }

        public override bool Validate()
        {
            foreach (var split in Splits)
            {
                if (!(split is PercentSplit))
                    return false;
            }

            double totalPercent = 0;
            double sumSplitPercent = 0;

            foreach (var split in Splits)
            {
                PercentSplit percentSplit = (PercentSplit)split;
                sumSplitPercent += percentSplit.Percent;
            }

            if (totalPercent != sumSplitPercent)
                return false;

            return true;
        }
    }
}