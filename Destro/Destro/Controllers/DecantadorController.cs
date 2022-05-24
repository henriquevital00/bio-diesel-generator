using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecantadorController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Decantador dec)
        {
            var decService = new DecantadorService();
            return decService.GetCapacity(dec);
        }

        [HttpPost]
        public object SetCapacityApi(Decantador dec, double quantity)
        {
            var decService = new DecantadorService();
            return decService.SetCapacityServ(dec, quantity);
        }

        [HttpGet]
        public double GetTransfer(Decantador dec)
        {
            var decService = new DecantadorService();
            return decService.GetTransfer(dec);
        }
    }
}
