using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtohController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetCapacity(etao);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(Etoh etao, double quantity)
        {
            var etaoService = new EtohService();
            return etaoService.SetCapacityServ(etao, quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetTransfer(etao);
        }
    }
}