using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    internal class Etoh : IMachines
    {

        public Etoh()
        {
            Capacity = 0;
            Flow = 0.25;
        }
    }
}
