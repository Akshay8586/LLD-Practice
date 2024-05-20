using System;

namespace ExpenseManagerApp.Model.Split
{
    public abstract class Split
    {
        private User user;
        protected double amount;

        public Split(User user)
        {
            this.user = user;
        }

        public Split(User user, double amount)
        {
            this.user = user;
            this.amount = amount;
        }

        public User GetUser()
        {
            return user;
        }

        public void SetUser(User user)
        {
            this.user = user;
        }

        public double GetAmount()
        {
            return amount;
        }

        public void SetAmount(double amount)
        {
            this.amount = amount;
        }
    }
}