using BioDieselProject.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Services
{
    public class DecantadorService
    {
        public double GetCapacity(Decantador dec)
        {
            return dec.Capacity;
        }
        public object SetCapacityServ(Decantador dec, double quantity)
        {
            return dec.setCapacity(quantity);
        }
        public object GetTransfer(Decantador dec)
        {
            return dec.trasfer();
        }
    }
}
