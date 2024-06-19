using System;
using StrategyPattern.Strategy;

namespace StrategyPattern.Strategy {
    public class SportsDriveStrategy : IDriveStrategy {
        public void Drive() {
            Console.WriteLine("Sports Drive Strategy");
        }
    }
}