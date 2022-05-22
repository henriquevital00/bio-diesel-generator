using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class DryerToEtOh : IMachines
    {
        public DryerToEtOh()
        {
            Capacity = 0;
            Waste = 0.05;
            Flow = 0.2;
        }

        public override double setCapacity(double quantity)
        {
            Capacity += quantity;
            return Capacity;
        }

        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity >= Flow)
            {
                transfer = Flow * Waste;
                Capacity -= Flow;
            }
            return transfer;
        }
    }
}
