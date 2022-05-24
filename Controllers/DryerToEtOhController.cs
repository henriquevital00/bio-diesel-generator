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
        [HttpGet]
        public double GetCapacity(DryerToEtOh dry)
        {
            var dryService = new DryerToEtOhService();
            return dryService.GetCapacity(dry);
        }

        [HttpPost]
        public object SetCapacityApi(DryerToEtOh dry, double quantity)
        {
            var dryService = new DryerToEtOhService();
            return dryService.SetCapacityServ(dry, quantity);
        }

        [HttpGet]
        public object GetTransfer(DryerToEtOh dry)
        {
            var dryService = new DryerToEtOhService();
            return dryService.GetTransfer(dry);
        }
    }
}
