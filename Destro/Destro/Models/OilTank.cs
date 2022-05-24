using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BioDieselProject.Entity
{
    public class OilTank : IMachines
    {

        public OilTank()
        {
            Capacity = 0;
            Flow = 0.75;
        }

        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity != 0) {
                if (Capacity <= Flow)
                transfer = Capacity;
                Capacity -= transfer;
            }
            else
            {
                transfer = Flow;
                Capacity -= transfer;
            }
            return transfer;
        }
    }
}
