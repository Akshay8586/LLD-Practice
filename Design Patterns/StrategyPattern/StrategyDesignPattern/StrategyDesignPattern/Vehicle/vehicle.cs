using StrategyPattern.Strategy;

namespace StrategyPattern.Vehicle {
    public class Vehicle {
        public IDriveStrategy driveStrategy;

        public Vehicle(IDriveStrategy driveStrategy) {
            this.driveStrategy = driveStrategy;
        }

        public void Drive() {
            this.driveStrategy.Drive();
        }
    }   
}