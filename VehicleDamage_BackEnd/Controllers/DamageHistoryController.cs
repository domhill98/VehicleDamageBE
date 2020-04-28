using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    [Route("api/DamageHistory")]
    [ApiController]
    public class DamageHistoryController : ControllerBase
    {
        private readonly VehicleDamageDB _context;

        public DamageHistoryController(VehicleDamageDB context)
        {
            _context = context;
        }

        [HttpGet("{lplate}")]
        public ActionResult<IEnumerable<DamageHistory>> GetDamageHistories(string lplate) 
        {
            if(lplate == null) 
            {
                return BadRequest();
            }

            var damage = _context.DamageHistory.Where(x => x.lplateNum == lplate);

            return Ok(damage);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateDamageHistory([FromBody]DamageHistory dto) 
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                _context.DamageHistory.Update(dto);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertDamageHistory([FromBody]DamageHistory dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
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