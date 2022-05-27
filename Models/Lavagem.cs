using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    public class Lavagem : IMachines

    {
        private double Waste = 0;
        public double Lost = 0;
        public Lavagem()
        {
            Capacity = 0;
            Flow = 1.5;
            Waste = 0.975;
        }

        // chamar a cada 3 segundos, pois existem 3 tanques com vazao de 1.5 l/s
        public override object trasfer()
        {
            double transfer = 0;
            double lost = 0;
            if (Capacity <= Flow)
            {
                Lost = Capacity - (Capacity * Waste);
                transfer = (((Capacity * Waste) * Waste) * Waste);
                Capacity -= transfer;
                Lost = lost;
            }
            else
            {
                Lost = Capacity - (Flow * Waste);
                transfer = (((Flow * Waste) * Waste) * Waste);
                Capacity -= transfer;
                Lost = lost;
            }
            return new { transfer, Lost };
        }
    }
}
