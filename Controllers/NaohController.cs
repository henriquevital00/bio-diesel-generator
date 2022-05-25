using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaohController : ControllerBase
    {
        [HttpGet("getCapacity")]
        public double GetCapacity(Naoh na)
        {
            var naService = new NaohService();
            return naService.GetCapacity(na);
        }

        [HttpPost("setCapcity")]
        public void SetCapacityApi(dynamic? state)
        {
            var naService = new NaohService();
            naService.SetCapacityServ(state.naOh, state.quantity);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Naoh na)
        {
            var naService = new NaohService();
            return naService.GetTransfer(na);
        }
    }
}