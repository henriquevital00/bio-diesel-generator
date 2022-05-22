﻿using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Reactor : IMachines
    {
        private double naOh = 0;
        private double etOh = 0;
        private double oil = 0;

        public Reactor()
        {
            Capacity = 0;
            Flow = 5;
            Volume = 5;
        }

        // metodo adiciona a quantidade que for possivel da substancia, se possivel adicionar tudo ele retorna o valor do que sobrou
        //da substancia
        public Tuple<double, double, double> setCapacityNaoh(double quantity)
        {
            double remeaning = Volume - Capacity;
            if (quantity <= remeaning)
            {
                Capacity += quantity;
                naOh += quantity;
                quantity = 0;
            }
            else
            {
                Capacity += remeaning;
                quantity -= remeaning;
                naOh += remeaning;
            }
            return Tuple.Create(Capacity, naOh, quantity);
        }

        public Tuple<double, double, double> setCapacityEtoh(double quantity)
        {
            double remeaning = Volume - Capacity;
            if (quantity <= remeaning)
            {
                Capacity += quantity;
                etOh += quantity;
                quantity = 0;
            }
            else
            {
                Capacity += remeaning;
                quantity -= remeaning;
                etOh += remeaning;
            }
            return Tuple.Create(Capacity, etOh, quantity);
        }

        public Tuple<double, double, double> setCapacityOil(double quantity)
        {
            double remeaning = Volume - Capacity;
            if (quantity <= remeaning)
            {
                Capacity += quantity;
                oil += quantity;
                quantity = 0;
            }
            else
            {
                Capacity += remeaning;
                quantity -= remeaning;
                oil += remeaning;
            }
            return Tuple.Create(Capacity, oil, quantity);
        }

        // Verificar, Destro escreveu o documento com o cu
        public override double trasfer()
        {
            double transfer = 0;
            if (Capacity >= Flow)
            {
                if()
                transfer = Flow;
                Capacity -= transfer;
            }
            return transfer;
        }
    }
}
