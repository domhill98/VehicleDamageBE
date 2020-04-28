using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleDamage_BackEnd.Models;
using VehicleDamage_BackEnd_Data;

namespace VehicleDamage_BackEnd.Controllers
{
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly VehicleDamageDB _context;

        public VehicleController(VehicleDamageDB context) 
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles() 
        {
            var vehicles = _context.Vehicle.Include(p => p.make).AsEnumerable();

            if(vehicles == null) 
            {
                return NotFound();
            }

            return Ok(vehicles);
        }

        [HttpGet("{lplateNum}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(string lplateNum) 
        {
            var vehicle = await _context.Vehicle.Include(p => p.make).Where(v => v.licenseNum == lplateNum).FirstOrDefaultAsync();

            if(vehicle == null) 
            {
                return NotFound();
            }

            return Ok(vehicle);
        }


        [HttpPost("Filtered")]
        public ActionResult<IEnumerable<Vehicle>> GetFilteredVehicles([FromBody]APIFilter filter) 
        {
            var vehicles = _context.Vehicle.Include(v => v.make).AsEnumerable();
            
            if (vehicles == null) 
            {
                return NotFound();
            }

            if(filter.makeID != Guid.Empty) 
            {
                vehicles = vehicles.Where(v => v.makeID == filter.makeID);
            }
            if(filter.state != null && filter.state != "All") 
            {
                vehicles = vehicles.Where(v => v.state == filter.state);
            }
            if(filter.lPlate != null) 
            {
                vehicles = vehicles.Where(v => v.licenseNum.Contains(filter.lPlate, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(vehicles);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateVehicle([FromBody]Vehicle dto)  
        {
            if(dto == null) 
            {
                return BadRequest();
            }

            try 
            {
                _context.Vehicle.Update(dto);
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