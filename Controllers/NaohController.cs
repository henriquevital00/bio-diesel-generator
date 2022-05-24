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
        [HttpGet]
        public double GetCapacity(Naoh na)
        {
            var naService = new NaohService();
            return naService.GetCapacity(na);
        }

        [HttpPost]
        public object SetCapacityApi(Naoh na, double quantity)
        {
            var naService = new NaohService();
            return naService.SetCapacityServ(na, quantity);
        }

        [HttpGet]
        public object GetTransfer(Naoh na)
        {
            var naService = new NaohService();
            return naService.GetTransfer(na);
        }
    }
}
