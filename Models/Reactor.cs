using BioDieselProject.Interfaces;
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
            Volume = 5;
        }

        // metodo adiciona a quantidade que for possivel da substancia, se possivel adicionar tudo ele retorna o valor do que sobrou
        //da substancia
        public object setCapacityNaoh(double quantity)
        {
            if (Capacity <= Volume)
            {
                double sobrou = Volume - Capacity;
                if (quantity <= sobrou)
                {
                    Capacity += quantity;
                    naOh += quantity;
                    quantity = 0;
                }
                else
                {
                    Capacity += sobrou;
                    naOh += sobrou;
                    quantity -= sobrou;
                }
            }
            return new
            {
                quantity
            };
        }

        public object setCapacityEtoh(double quantity)
        {
            if (Capacity <= Volume)
            {
                double sobrou = Volume - Capacity;
                if (quantity <= sobrou)
                {
                    Capacity += quantity;
                    etOh += quantity;
                    quantity = 0;
                }
                else
                {
                    Capacity += sobrou;
                    etOh += sobrou;
                    quantity -= sobrou;
                }
            }
            return new
            {
                quantity
            };
        }

        public object setCapacityOil(double quantity)
        {
            if (Capacity <= Volume)
            {
                double sobrou = Volume - Capacity;
                if (quantity <= sobrou)
                {
                    Capacity += quantity;
                    oil += quantity;
                    quantity = 0;
                }
                else
                {
                    Capacity += sobrou;
                    oil += sobrou;
                    quantity -= sobrou;
                }
            }
            return new
            {
                quantity
            };
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
