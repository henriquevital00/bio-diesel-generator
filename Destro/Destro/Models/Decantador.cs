using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Decantador : IMachines
    {
        private bool sleeping = false;
        public Decantador()
        {
            Capacity = 0;
            Flow = 1;
            Volume = 10;
        }


        // Separar o transfer em 1% glicerina 96% solucao e 3% EtOh para mostrar no terminal
        public override object trasfer()
        {
            double transfer = 0;
            sleeping = !sleeping;

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
                
            return new { transfer };
        }
    }
}
