using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    public class Decantador : IMachines
    {
        private bool sleeping = false;
        public Decantador()
        {
            Capacity = 0;
            Flow = 1;
            Volume = 10;
        }

        public override object setCapacity(double quantity)
        {
            double remeaning = Volume - Capacity;
            if (quantity <= remeaning)
            {
                Capacity += quantity;
                quantity = 0;
            }
            else
            {
                Capacity += remeaning;
                quantity -= remeaning;
            }
            return new { Capacity, quantity };
        }


        // Separar o transfer em 1% glicerina 96% solucao e 3% EtOh para mostrar no terminal
        public override double trasfer()
        {
            double transfer = 0;

            if (!sleeping)
            {
                if (Capacity >= Flow)
                {
                    transfer = Flow;
                    Capacity -= Flow;
                }
                else
                {
                    double sobra = Flow - Capacity;
                    transfer = sobra;
                    Capacity -= sobra;
                }
                sleeping = true;
            }
            return transfer;
        }
    }
}
