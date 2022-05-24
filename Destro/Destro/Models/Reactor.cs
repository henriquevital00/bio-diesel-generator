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
        private double naOh = 0;
        private double etOh = 0;
        private double oil = 0;

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
                etOh,
                naOh,
                oil
            };
        }

        public Tuple<double, double, double> setCapacityEtoh(double quantity)
        {
            Capacity += quantity;
            etOh += quantity;
            return Tuple.Create(Capacity, etOh, quantity);
        }

        public Tuple<double, double, double> setCapacityOil(double quantity)
        {
            Capacity += quantity;
            oil += quantity;
            return Tuple.Create(Capacity, oil, quantity);
        }

        // Verificar, Destro escreveu o documento com o cu
        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity > 0)
            {
                if (Capacity <= Flow)
                {
                    //if()
                    transfer = Capacity;
                    Capacity -= transfer;
                }
                else
                {
                    transfer = Flow;
                    Capacity -= transfer;
                }
            }
            return transfer;
        }
    }
}
