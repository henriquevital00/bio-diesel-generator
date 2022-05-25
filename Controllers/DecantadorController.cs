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
        [HttpGet("getCapacity")]
        public double GetCapacity(Decantador dec)
        {
            var decService = new DecantadorService();
            return decService.GetCapacity(dec);
        }

        [HttpPost("setCapcity")]
        public object SetCapacityApi(Decantador dec, double quantity)
        {
            var decService = new DecantadorService();
            return decService.SetCapacityServ(dec, quantity);
        }

        [HttpPost("setStatus")]
        public void SetStatusApi(dynamic? state)
        {
            var decService = new DecantadorService();
            decService.SetStateServ(state.decantador);
        }

        [HttpGet("getTransfer")]
        public object GetTransfer(Decantador dec)
        {
            var decService = new DecantadorService();
            return decService.GetTransfer(dec);
        }
    }
}﻿