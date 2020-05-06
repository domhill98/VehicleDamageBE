using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    //Routing for the api
    [Route("api/ClockHistory")]
    [ApiController]
    public class ClockHistoryController : ControllerBase
    {

        private readonly VehicleDamageDB _context;

        public ClockHistoryController(VehicleDamageDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the Clock Hitories records for given licence plate
        /// </summary>
        /// <param name="lplate">LPlate to search for</param>
        /// <returns>List of Clock History Entries</returns>
        [HttpGet("{lplate}")]
        public ActionResult<IEnumerable<ClockHistory>> GetClockHistories(string lplate)
        {
            if(lplate == null) 
            {
                return BadRequest();
            }
            //Filter clock history elements
            var clock = _context.ClockHistory.Where(x => x.lplateNum == lplate);

            return Ok(clock);
        }

        /// <summary>
        /// Insert clock history
        /// </summary>
        /// <param name="dto">Passed from the body. Is the dto element to upload</param>
        /// <returns></returns>
        [HttpPost("Insert")]
        public async Task<ActionResult> InsertClockHistory([FromBody]ClockHistory dto) 
        {
            if(dto == null) 
            {
                return BadRequest();
            }

            try 
            {
                //Insert and save db
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