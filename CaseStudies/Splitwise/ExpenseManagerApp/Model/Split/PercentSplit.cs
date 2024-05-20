using System;

namespace ExpenseManagerApp.Model.Split
{
    public class PercentSplit : Split
    {
        public double Percent { get; set; }

        public PercentSplit(User user, double percent) : base(user)
        {
            this.Percent = percent;
        }
    }
}