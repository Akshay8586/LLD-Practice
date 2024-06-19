using System;

namespace StrategyPattern.Strategy {
    public class NormalDriveStrategy : IDriveStrategy {
        public void Drive() {
            Console.WriteLine("Normal Drive Strategy");
        }
    }
}
