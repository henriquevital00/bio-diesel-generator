using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BioDieselProject.Entity
{
    internal class OilTank : IMachines
    {

        public OilTank()
        {
            Capacity = 0;
            Flow = 0.75;
        }

        public override double setCapacity(double quantity)
        {
            Capacity += quantity;
            return Capacity;
        }

        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity >= Flow) {
                transfer = Flow;
                Capacity -= transfer;
            }
            return transfer;
        }
    }
}
