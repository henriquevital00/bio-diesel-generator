using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactorController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetCapacity(react);
        }

        [HttpPost]
        public object SetCapacityApi(Reactor react, double quantity)
        {
            var reactService = new ReactorService();
            return reactService.SetCapacityServ(react, quantity);
        }

        [HttpGet]
        public object GetTransfer(Reactor react)
        {
            var reactService = new ReactorService();
            return reactService.GetTransfer(react);
        }
    }
}
