using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlicerineController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Glicerine glic)
        {
            var glicService = new GlicerineService();
            return glicService.GetCapacity(glic);
        }

        [HttpPost]
        public object SetCapacityApi(Glicerine glic, double quantity)
        {
            var glicService = new GlicerineService();
            return glicService.SetCapacityServ(glic, quantity);
        }

        [HttpGet]
        public object GetTransfer(Glicerine glic)
        {
            var glicService = new GlicerineService();
            return glicService.GetTransfer(glic);
        }
    }
}
