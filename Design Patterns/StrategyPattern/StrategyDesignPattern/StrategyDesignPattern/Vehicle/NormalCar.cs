
using System.ComponentModel;
using StrategyPattern.Strategy;

namespace StrategyPattern.Vehicle {
    public class NormalCar : Vehicle {
        public NormalCar(): base(new NormalDriveStrategy()) { 
            
        }
    }
}