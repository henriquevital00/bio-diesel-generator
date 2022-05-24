using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DryerToEtOhController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(DryerToEtOh dry)
        {
            var dryService = new DryerToEtOhService();
            return dryService.GetCapacity(dry);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(DryerToEtOh dry, double quantity)
        {
            var dryService = new DryerToEtOhService();
            return dryService.SetCapacityServ(dry, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(DryerToEtOh dry)
        {
            var dryService = new DryerToEtOhService();
            return dryService.GetTransfer(dry);
        }
    }
}