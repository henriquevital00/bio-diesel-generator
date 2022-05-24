using BioDieselProject.Interfaces;

namespace BioDieselProject.Entity
{
    internal class Dryer : IMachines
    {
        public Dryer()
        {
            Capacity = 0;
            Waste = 0.05;
            Flow = 0.2;
        }

        public override object setCapacity(double quantity)
        {
            Capacity += quantity;
            return new { Capacity };
        }
    }
}
