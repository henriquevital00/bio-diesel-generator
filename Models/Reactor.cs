﻿using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    public class Reactor : IMachines
    {
        public double naOh = 0;
        public double etOh = 0;
        public double oil = 0;

        public Reactor()
        {
            Capacity = 0;
            Flow = 5;
        }

        // metodo adiciona a quantidade que for possivel da substancia, se possivel adicionar tudo ele retorna o valor do que sobrou
        //da substancia
        public object setCapacityNaoh(double quantity)
        {
            Capacity += quantity;
            naOh += quantity;
            return new
            {
                Capacity,
                naOh
            };
        }

        public object setCapacityEtoh(double quantity)
        {
            Capacity += quantity;
            etOh += quantity;
            return new { Capacity, etOh };
        }

        public object setCapacityOil(double quantity)
        {
            Capacity += quantity;
            oil += quantity;
            return new { Capacity, oil };
        }

        // Verificargit clone
        public override object trasfer()
        {
            double transfer = 0;
            if (Capacity > 0)
            {
                if (Capacity <= Flow)
                {
                    double parte = Capacity/4;
                    if (naOh >= parte && etOh >= parte && oil >= (parte * 2))
                    {
                        transfer = Capacity;
                        Capacity -= transfer;
                        naOh -= parte;
                        etOh -= parte;
                        oil -= (parte*2);
                    }
                }
                else
                {
                    double parte = Flow / 4;
                    if (naOh >= parte && etOh >= parte && oil >= (parte * 2))
                    {
                        transfer = Flow;
                        Capacity -= transfer;
                        naOh -= parte;
                        etOh -= parte;
                        oil -= (parte*2);
                    }
                }
            }
            return new { transfer, naOh, etOh, oil };
        }
    }
}
