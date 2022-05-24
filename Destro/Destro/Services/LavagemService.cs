using BioDieselProject.Entity;

namespace Destro.Services
{
    public class LavagemService
    {
        public double GetCapacity(Lavagem lav)
        {
            return lav.Capacity;
        }
        public object SetCapacityServ(Lavagem lav, double quantity)
        {
            return lav.setCapacity(quantity);
        }
        public object GetTransfer(Lavagem lav)
        {
            return lav.trasfer();
        }
    }
}
