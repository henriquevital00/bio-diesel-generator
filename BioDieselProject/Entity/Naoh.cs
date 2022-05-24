using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Naoh : IMachines
    {
        private double naOh = 0;

        public Naoh()
        {
            Capacity = 0;
            Flow = 0.5;
        }

        public override object setCapacity(double substance1)
        {
            naOh = substance1;
            Capacity = substance1;
            return new { Capacity, naOh };
        }

        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity >= Flow)
            {
                transfer = Flow;
                naOh -= Flow;
                Capacity -= Flow;
            }
            return transfer;
        }
    }
}
