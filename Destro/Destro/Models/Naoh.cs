using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Entity
{
    public class Naoh : IMachines
    {
        public Naoh()
        {
            Capacity = 0;
            Flow = 0.5;
        }
    }
}
