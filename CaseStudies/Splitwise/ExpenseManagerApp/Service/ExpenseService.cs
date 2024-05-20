using System;
using System.Collections.Generic;

namespace ExpenseManagerApp.Service
{
    using ExpenseManagerApp.Model;
    using Model.Expense;
    using Model.Split;

    public class ExpenseService
    {
        public static Expense CreateExpense(ExpenseType expenseType, double amount, User paidBy, List<Split> splits)
        {
            switch (expenseType)
            {
                case ExpenseType.EXACT:
                    return new ExactExpense(amount, paidBy, splits);
                case ExpenseType.EQUAL:
                    int totalSplitSize = splits.Count;
                    double splitAmount = Math.Round(amount * 100 / totalSplitSize) / 100.0;
                    foreach (Split split in splits)
                    {
                        split.SetAmount(splitAmount);
                    }

                    splits[0].SetAmount(splitAmount + amount - splitAmount * totalSplitSize);
                    return new EqualExpense(amount, paidBy, splits);
                case ExpenseType.PERCENT:
                    foreach (Split split in splits)
                    {
                        PercentSplit percentSplit = (PercentSplit)split;
                        split.SetAmount((amount * percentSplit.Percent) / 100.0);
                    }
                    return new PercentExpense(amount, paidBy, splits);
            }

            return null;
        }
    }
}