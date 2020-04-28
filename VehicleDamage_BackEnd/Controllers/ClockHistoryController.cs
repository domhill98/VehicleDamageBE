using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    [Route("api/ClockHistory")]
    [ApiController]
    public class ClockHistoryController : ControllerBase
    {

        private readonly VehicleDamageDB _context;

        public ClockHistoryController(VehicleDamageDB context)
        {
            _context = context;
        }

        [HttpGet("{lplate}")]
        public ActionResult<IEnumerable<ClockHistory>> GetClockHistories(string lplate)
        {
            if(lplate == null) 
            {
                return BadRequest();
            }

            var clock = _context.ClockHistory.Where(x => x.lplateNum == lplate);

            return Ok(clock);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertClockHistory([FromBody]ClockHistory dto) 
        {
            if(dto == null) 
            {
                return BadRequest();
            }

            try 
            {
                _context.ClockHistory.Add(dto);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }


    }
}