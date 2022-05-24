using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioDieselController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(BioDiesel bio)
        {
            var bioService = new BioDieselService();
            return bioService.GetCapacity(bio);

        }
    }
}
