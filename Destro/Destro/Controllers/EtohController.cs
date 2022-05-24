<<<<<<< HEAD
﻿using BioDieselProject.Entity;
using Destro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtohController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetCapacity(etao);
        }

        [HttpPost]
        public object SetCapacityApi(Etoh etao, double quantity)
        {
            var etaoService = new EtohService();
            return etaoService.SetCapacityServ(etao, quantity);
        }

        [HttpGet]
        public object GetTransfer(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetTransfer(etao);
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
    public class EtohController : ControllerBase
    {
        [HttpGet]
        public double GetCapacity(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetCapacity(etao);
        }

        [HttpPost]
        public object SetCapacityApi(Etoh etao, double quantity)
        {
            var etaoService = new EtohService();
            return etaoService.SetCapacityServ(etao, quantity);
        }

        [HttpGet]
        public double GetTransfer(Etoh etao)
        {
            var etaoService = new EtohService();
            return etaoService.GetTransfer(etao);
        }
    }
}
>>>>>>> 122cc5460b05e9483b1f9b5f5cba8ec97f80e87c
