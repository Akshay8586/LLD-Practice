
using StrategyPattern.Vehicle;

namespace StrategyPattern.Driver {
    public class Driver {
        public static void Main(string[] args) {
            Vehicle.Vehicle vehicle = new NormalCar();
            vehicle.Drive();
        }
    }
}
