using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilTankController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(OilTank oil)
        {
            var oilService = new OilTankService();
            return oilService.GetCapacity(oil);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(OilTank oil, double quantity)
        {
            var oilService = new OilTankService();
            return oilService.SetCapacityServ(oil, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(OilTank oil)
        {
            var oilService = new OilTankService();
            return oilService.GetTransfer(oil);
        }
    }
}
