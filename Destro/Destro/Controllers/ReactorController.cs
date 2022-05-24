<<<<<<< HEAD
﻿using BioDieselProject.Entity;
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
=======
﻿using BioDieselProject.Entity;
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
>>>>>>> 122cc5460b05e9483b1f9b5f5cba8ec97f80e87c
