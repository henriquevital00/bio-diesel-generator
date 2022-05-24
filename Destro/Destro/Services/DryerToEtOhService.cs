using BioDieselProject.Entity;

namespace Destro.Services
{
    public class DryerToEtOhService
    {
        public double GetCapacity(DryerToEtOh doet)
        {
            return doet.Capacity;
        }
        public object SetCapacityServ(DryerToEtOh doet, double quantity)
        {
            return doet.setCapacity(quantity);
        }
        public object GetTransfer(DryerToEtOh doet)
        {
            return doet.trasfer();
        }
    }
}
