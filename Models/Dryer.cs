using BioDieselProject.Interfaces;

namespace BioDieselProject.Entity
{
    public class Dryer : IMachines
    {
        public double lost = 0;
        public Dryer()
        {
            Capacity = 0;
            Waste = 0.95;
            Flow = 0.2;
        }

        public override object trasfer()
        {
            double transfer = 0;
            if (Capacity > 0)
            {
                if (Capacity <= Flow)
                {
                    lost = Capacity - (Capacity * Waste);
                    transfer = Capacity * Waste;
                    Capacity -= transfer;
                }
                else
                {
                    lost = Capacity - (Flow * Waste);
                    transfer = Flow * Waste;
                    Capacity -= transfer;
                }
            }
            return new { transfer, lost };
        }
    }
}
