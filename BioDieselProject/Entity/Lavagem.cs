using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Lavagem : IMachines

    {
        private double Waste = 0;
        public Lavagem()
        {
            Capacity = 0;
            Flow = 1.5;
            Waste = 0.075;
        }

        public override double setCapacity(double quantity)
        {
            Capacity += quantity;
            return Capacity;
        }

        // chamar a cada 3 segundos, pois existem 3 tanques com vazao de 1.5 l/s
        public override double trasfer()
        {
            double transfer = 0;
            transfer = Capacity * Waste;
            return transfer;
        }
    }
}
