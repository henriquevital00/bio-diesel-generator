using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DryerController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(Dryer dry)
        {
            var dryService = new DryerService();
            return dryService.GetCapacity(dry);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(Dryer dry, double quantity)
        {
            var dryService = new DryerService();
            return dryService.SetCapacityServ(dry, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Dryer dry)
        {
            var dryService = new DryerService();
            return dryService.GetTransfer(dry);
        }
    }
}