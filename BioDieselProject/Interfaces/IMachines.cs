using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioDieselProject.Interfaces
{
    internal abstract class IMachines
    {
        public double Capacity{ get; set; }

        public double Flow{ get; set; }

        public double Volume { get; set; }

        public double Waste { get; set; }


        public abstract double setCapacity(double quantity);

        public abstract double trasfer();
        
    }
}
