using BioDieselProject.Entity;

namespace Destro.Services
{
    public class GlicerineService
    {
        public double GetCapacity(Glicerine glic)
        {
            return glic.Capacity;
        }
        public object SetCapacityServ(Glicerine glic, double quantity)
        {
            return glic.setCapacity(quantity);
        }
        public object GetTransfer(Glicerine glic)
        {
            return glic.trasfer();
        }
    }
}
