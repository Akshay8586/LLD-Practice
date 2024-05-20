// Framework: None
// Technology stack: None

using System;
using System.Collections.Generic;
using ExpenseManagerApp.Model;
using ExpenseManagerApp.Model.Split;
using ExpenseManagerApp.Service;

namespace ExpenseManagerApp
{
    public class Driver
    {
        public static void Main(string[] args)
        {
            ExpenseManager expenseManager = new ExpenseManager();

            expenseManager.AddUser(new User("u1", "User1", "abc@gmail.com", 1234567890));
            expenseManager.AddUser(new User("u2", "User2", "abc1@gmail.com", 1234567891));
            expenseManager.AddUser(new User("u3", "User3", "abc2@gmail.com", 1234567892));
            expenseManager.AddUser(new User("u4", "User4", "abc3@gmail.com", 1234567893));

            Console.WriteLine("Enter command:");
            while (true)
            {
                string command = Console.ReadLine();
                string[] commands = command.Split(" ");
                string commandType = commands[0];

                switch (commandType)
                {
                    case "EXIT":
                        System.Environment.Exit(1);
                        break;
                    case "SHOW":
                        if (commands.Length == 1)
                        {
                            expenseManager.ShowBalances();
                        }
                        else
                        {
                            expenseManager.ShowExpense(commands[1]);
                        }
                        break;
                    case "EXPENSE":
                        string paidBy = commands[1];
                        double amount = double.Parse(commands[2]);
                        int noOfUsers = int.Parse(commands[3]);
                        string expenseType = commands[4 + noOfUsers];
                        List<Split> splits = new List<Split>();
                        switch (expenseType)
                        {
                            case "EQUAL":
                                for (int i = 0; i < noOfUsers; i++)
                                {
                                    splits.Add(new EqualSplit(expenseManager.userMap[commands[4 + i]]));
                                }
                                expenseManager.AddExpense(ExpenseType.EQUAL, amount, paidBy, splits);
                                break;
                            case "EXACT":
                                for (int i = 0; i < noOfUsers; i++)
                                {
                                    splits.Add(new ExactSplit(expenseManager.userMap[commands[4 + i]], double.Parse(commands[5 + noOfUsers + i])));
                                }
                                expenseManager.AddExpense(ExpenseType.EXACT, amount, paidBy, splits);
                                break;
                            case "PERCENT":
                                for (int i = 0; i < noOfUsers; i++)
                                {
                                    splits.Add(new PercentSplit(expenseManager.userMap[commands[4 + i]], double.Parse(commands[5 + noOfUsers + i])));
                                }
                                expenseManager.AddExpense(ExpenseType.PERCENT, amount, paidBy, splits);
                                break;
                        }
                        break;
                }
            }
        }
    }
}