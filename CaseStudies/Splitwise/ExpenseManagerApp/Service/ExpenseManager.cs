using System.Collections.Generic;
using ExpenseManagerApp.Model;
using ExpenseManagerApp.Model.Expense;
using ExpenseManagerApp.Model.Split;

namespace ExpenseManagerApp.Service
{
    public class ExpenseManager
    {
        private List<Expense> expenses;
        public Dictionary<string, User> userMap;
        private Dictionary<string, Dictionary<string, double>> balanceSheet;

        public ExpenseManager()
        {
            expenses = new List<Expense>();
            userMap = new Dictionary<string, User>();
            balanceSheet = new Dictionary<string, Dictionary<string, double>>();
        }

        public void AddUser(User user)
        {
            userMap.Add(user.Id, user);
            balanceSheet.Add(user.Id, new Dictionary<string, double>());
        }

        public void AddExpense(ExpenseType expenseType, double amount, string paidBy, List<Split> splits)
        {
            Expense expense = ExpenseService.CreateExpense(expenseType, amount, userMap[paidBy], splits);
            expenses.Add(expense);

            foreach (Split split in splits)
            {
                string paidTo = split.GetUser().Id;
                Dictionary<string, double> balances = balanceSheet[paidBy];

                if (!balances.ContainsKey(paidTo))
                    balances.Add(paidTo, 0.0);

                balances[paidTo] += split.GetAmount();

                balances = balanceSheet[paidTo];

                if (!balances.ContainsKey(paidBy))
                    balances.Add(paidBy, 0.0);

                balances[paidBy] -= split.GetAmount();
            }
        }

        public void ShowExpense(string userId)
        {
            bool isEmpty = true;

            foreach (KeyValuePair<string, double> userBalance in balanceSheet[userId])
            {
                if (userBalance.Value != 0)
                {
                    isEmpty = false;
                    PrintBalance(userId, userBalance.Key, userBalance.Value);
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("No Balances");
            }
        }

        private void PrintBalance(string user1, string user2, double amount)
        {
            string user1Name = userMap[user1].Name;
            string user2Name = userMap[user2].Name;
            if (amount < 0)
            {
                Console.WriteLine(user1Name + " owes " + user2Name + ": " + Math.Abs(amount));
            }
            else if (amount > 0)
            {
                Console.WriteLine(user2Name + " owes " + user1Name + ": " + Math.Abs(amount));
            }
        }

        public void ShowBalances()
        {
            bool isEmpty = true;

            foreach (KeyValuePair<string, Dictionary<string, double>> allBalances in balanceSheet)
            {
                foreach (KeyValuePair<string, double> userBalance in allBalances.Value)
                {
                    if (userBalance.Value > 0)
                    {
                        isEmpty = false;
                        PrintBalance(allBalances.Key, userBalance.Key, userBalance.Value);
                    }
                }
            }

            if (isEmpty)
            {
                Console.WriteLine("No Balances");
            }
        }
    }
}