using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    //Api Routing
    [Route("api/DamageHistory")]
    [ApiController]
    public class DamageHistoryController : ControllerBase
    {
        private readonly VehicleDamageDB _context;

        public DamageHistoryController(VehicleDamageDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of Damage History records for given lisence plate
        /// </summary>
        /// <param name="lplate">lplate to search for</param>
        /// <returns>List of Damage History Records</returns>
        [HttpGet("{lplate}")]
        public ActionResult<IEnumerable<DamageHistory>> GetDamageHistories(string lplate) 
        {
            if(lplate == null) 
            {
                return BadRequest();
            }

            //Filter for lplate
            var damage = _context.DamageHistory.Where(x => x.lplateNum == lplate);

            return Ok(damage);
        }

        /// <summary>
        /// Update Damage History record in db
        /// </summary>
        /// <param name="dto">Record to be updated with new values</param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateDamageHistory([FromBody]DamageHistory dto) 
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                //Update and save the db context
                _context.DamageHistory.Update(dto);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add Damage History record in db
        /// </summary>
        /// <param name="dto">Record to be added</param>
        /// <returns>HTTP Response</returns>
        [HttpPost("Insert")]
        public async Task<ActionResult> InsertDamageHistory([FromBody]DamageHistory dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                //Add and save the db context
                _context.DamageHistory.Add(dto);
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