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
            Waste = 0.925;
        }

        // chamar a cada 3 segundos, pois existem 3 tanques com vazao de 1.5 l/s
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
