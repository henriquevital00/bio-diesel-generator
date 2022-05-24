using BioDieselProject.Entity;

namespace Destro.Services
{
    public class ReactorService
    {
        public double GetCapacity(Reactor rea)
        {
            return rea.Capacity;
        }
        public double GetCapacityNaoh(Reactor rea)
        {
            return rea.naOh;
        }
        public double GetCapacityEtoh(Reactor rea)
        {
            return rea.etOh;
        }
        public double GetCapacityOil(Reactor rea)
        {
            return rea.oil;
        }

        public object SetCapacityNaohServ(Reactor rea, double quantity)
        {
            return rea.setCapacityNaoh(quantity);
        }

        public object SetCapacityEtohServ(Reactor rea, double quantity)
        {
            return rea.setCapacityEtoh(quantity);
        }

        public object SetCapacityOilServ(Reactor rea, double quantity)
        {
            return rea.setCapacityOil(quantity);
        }
        public object GetTransfer(Reactor rea)
        {
            return rea.trasfer();
        }
    }
}
