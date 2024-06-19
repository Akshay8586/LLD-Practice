
using System.ComponentModel;
using StrategyPattern.Strategy;

namespace StrategyPattern.Vehicle {
    public class SportsCar : Vehicle {
        public SportsCar(): base(new SportsDriveStrategy()) { }
    }
}