using BioDieselProject.Entity;

namespace Destro.Services
{
    public class NaohService
    {
        public double GetCapacity(Naoh na)
        {
            return na.Capacity;
        }
        public object SetCapacityServ(Naoh na, double quantity)
        {
            return na.setCapacity(quantity);
        }
        public object GetTransfer(Naoh na)
        {
            return na.trasfer();
        }
    }
}
