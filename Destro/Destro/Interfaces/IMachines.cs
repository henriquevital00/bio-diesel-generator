using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BioDieselProject.Interfaces
{
    public abstract class IMachines
    {
        public double Capacity{ get; set; }

        public double Flow{ get; set; }

        public double Volume { get; set; }

        public double Waste { get; set; }

        public virtual object setCapacity(double quantity)
        {
            Capacity += quantity;

            return new { Capacity };
        }

        public virtual double trasfer()
        {
            double transfer = 0;
            if (Capacity > 0)
            {
                if (Capacity <= Flow)
                {
                    transfer = Capacity;
                    Capacity -= transfer;
                }
                else
                {
                    transfer = Flow;
                    Capacity -= transfer;
                }
            }
            return transfer;
        }
        
    }
}
