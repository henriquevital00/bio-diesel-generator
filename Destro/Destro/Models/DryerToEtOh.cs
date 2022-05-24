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
            Waste = 0.95;
            Flow = 0.2;
        }

        public override object trasfer()
        {
            double transfer = 0;
            double lost = 0;
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
            return new { transfer, lost };
        }
    }
}
