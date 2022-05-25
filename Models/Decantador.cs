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
        private int timeToSleep = 5;
        public Decantador()
        {
            Capacity = 0;
            Flow = 1;
            Volume = 10;
        }

        public override object setCapacity(double quantity)
        {
            if (Capacity <= Volume)
            {
                double sobrou = Volume - Capacity;
                if (quantity <= sobrou)
                {
                    Capacity += quantity;
                    quantity = 0;
                }
                else
                {
                    Capacity += sobrou;
                    quantity -= sobrou;
                }
            }
            return new
            {
                quantity
            };
        }


        // Separar o transfer em 1% glicerina 96% solucao e 3% EtOh para mostrar no terminal
        public override object trasfer()
        {
            double transfer = 0;

            if (!sleeping)
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
                
            return new { transfer };
        }

        public void setState()
        {
            if (sleeping)
            {
                timeToSleep--;
                if (timeToSleep == 0)
                {
                    sleeping = false;
                    timeToSleep = 5;
                }
            }
        }
    }
}
