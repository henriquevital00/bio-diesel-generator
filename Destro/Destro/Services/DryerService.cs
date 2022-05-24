using BioDieselProject.Entity;

namespace Destro.Services
{
    public class DryerService
    {
        public double GetCapacity(Dryer dry)
        {
            return dry.Capacity;
        }
        public object SetCapacityServ(Dryer dry, double quantity)
        {
            return dry.setCapacity(quantity);
        }
        public object GetTransfer(Dryer dry)
        {
            return dry.trasfer();
        }
    }
}
