using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    [Route("api/Make")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly VehicleDamageDB _context;

        public MakeController(VehicleDamageDB context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Make>> GetMakes()
        {
            var clock = _context.ClockHistory.AsEnumerable();

            return Ok(clock);
        }


    }
}