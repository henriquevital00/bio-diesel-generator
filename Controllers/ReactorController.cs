using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactorController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetCapacity(react);
        }

        [HttpGet("getCapacityNaoh")]
        public double GetCapacityNaoh(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetCapacityNaoh(react);
        }

        [HttpGet("getCapacityEtoh")]
        public double GetCapacityEtoh(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetCapacityEtoh(react);
        }

        [HttpGet("getCapacityOil")]
        public double GetCapacityOil(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetCapacityOil(react);
        }

        [HttpPost("setCapcityNaoh")]
        public object SetCapacityNaohApi(Reactor react, double quantity)
        {
            var reactService = new ReactorService();
            return reactService.SetCapacityNaohServ(react, quantity);
        }

        [HttpPost("setCapcityEtoh")]
        public object SetCapacityEtohApi(Reactor react, double quantity)
        {
            var reactService = new ReactorService();
            return reactService.SetCapacityEtohServ(react, quantity);
        }

        [HttpPost("setCapcityOil")]
        public object SetCapacityOilApi(Reactor react, double quantity)
        {
            var reactService = new ReactorService();
            return reactService.SetCapacityOilServ(react, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetTransfer(react);
        }
    }
}