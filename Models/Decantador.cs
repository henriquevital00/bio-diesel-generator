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

        public object setCapacity(dynamic quantity)
        {
            if (Capacity <= Volume)
            {
                var diff = Volume - Capacity;
                var volAbsoluto = diff / 4;
                if (quantity.transfer >= diff)
                {
                    quantity.etOh -= volAbsoluto;
                    quantity.naOh -= volAbsoluto;
                    quantity.oil -= volAbsoluto*2;
                    var volumeNaoh = volAbsoluto;
                    var volumeEtoh = volAbsoluto;
                    var volumeOleo = 2 * volAbsoluto;
                    Capacity += diff;
                }
                else
                {
                    quantity.etOh = 0;
                    quantity.naOh = 0;
                    quantity.oil = 0;
                    var volumeNaoh = quantity.naOh;
                    var volumeEtoh = quantity.etOh;
                    var volumeOleo = 2 * quantity.oil;

                    Capacity += quantity.transfer;
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

            return new { transfer, Glicerine = transfer * 0.01 , etOh = transfer*0.03, solution = transfer*0.96 };
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
