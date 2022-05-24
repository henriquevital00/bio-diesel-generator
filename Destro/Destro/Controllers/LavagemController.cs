<<<<<<< HEAD
﻿using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavagemController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetCapacity(lav);
        }

        [HttpPost]
        public object SetCapacityApi(Lavagem lav, double quantity)
        {
            var lavService = new LavagemService();
            return lavService.SetCapacityServ(lav, quantity);
        }

        [HttpGet]
        public object GetTransfer(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetTransfer(lav);
        }
    }
}
=======
﻿using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavagemController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetCapacity(lav);
        }

        [HttpPost]
        public object SetCapacityApi(Lavagem lav, double quantity)
        {
            var lavService = new LavagemService();
            return lavService.SetCapacityServ(lav, quantity);
        }

        [HttpGet]
        public double GetTransfer(Lavagem lav)
        {
            var lavService = new LavagemService();
            return lavService.GetTransfer(lav);
        }
    }
}
>>>>>>> 122cc5460b05e9483b1f9b5f5cba8ec97f80e87c
