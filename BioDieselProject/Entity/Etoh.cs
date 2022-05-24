using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Etoh : IMachines
    {
        private double etOh = 0;

        public Etoh()
        {
            Capacity = 0;
            Flow = 0.25;
        }

        public override object setCapacity(double substance1)
        {
            etOh += substance1;
            Capacity += substance1;
            return new {Capacity, etOh};
        }
        

        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity >= Flow)
            {
                transfer = Flow;
                etOh -= Flow;
                Capacity -= transfer;
                
            }

            return transfer;
        }
    }
}
