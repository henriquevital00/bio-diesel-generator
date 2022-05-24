using BioDieselProject.Entity;

namespace Destro.Services
{
    public class ReactorService
    {
        public double GetCapacity(Reactor rea)
        {
            return rea.Capacity;
        }
        public object SetCapacityServ(Reactor rea, double quantity)
        {
            return rea.setCapacity(quantity);
        }
        public double GetTransfer(Reactor rea)
        {
            return rea.trasfer();
        }
    }
}
