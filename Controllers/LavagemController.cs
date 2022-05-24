using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavagemController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetCapacity(lav);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(Lavagem lav, double quantity)
        {
            var lavService = new LavagemService();
            return lavService.SetCapacityServ(lav, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetTransfer(lav);
        }
    }
}
