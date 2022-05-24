using BioDieselProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BioDieselProject.Entity
{
    public class OilTank : IMachines
    {

        public OilTank()
        {
            Capacity = 0;
            Flow = 0.75;
        }
    }
}
