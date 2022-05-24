using BioDieselProject.Entity;

namespace Destro.Services
{
    public class OilTankService
    {
        public double GetCapacity(OilTank oil)
        {
            return oil.Capacity;
        }
        public object SetCapacityServ(OilTank oil, double quantity)
        {
            return oil.setCapacity(quantity);
        }
        public double GetTransfer(OilTank oil)
        {
            return oil.trasfer();
        }
    }
}
