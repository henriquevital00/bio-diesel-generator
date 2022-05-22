using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Glicerine : IMachines
    {
        public Glicerine()
        {
            Capacity = 0;
        }

        public override double setCapacity(double quantity)
        {
            Capacity += quantity;
            return Capacity;
        }

        public override double trasfer()
        {
            throw new NotImplementedException();
        }
    }
}
