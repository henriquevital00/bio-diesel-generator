using BioDieselProject.Entity;

namespace Destro.Services
{
    public class EtohService
    {
        public double GetCapacity(Etoh et)
        {
            return et.Capacity;
        }
        public object SetCapacityServ(Etoh et, double quantity)
        {
            return et.setCapacity(quantity);
        }
        public object GetTransfer(Etoh et)
        {
            return et.trasfer();
        }
    }
}
