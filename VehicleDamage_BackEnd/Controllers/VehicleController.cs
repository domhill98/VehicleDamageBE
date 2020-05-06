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
    //API routing
    [Route("api/Vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly VehicleDamageDB _context;

        public VehicleController(VehicleDamageDB context) 
        {
            _context = context;
        }

        /// <summary>
        /// Get all vehicles in the db
        /// </summary>
        /// <returns>List of vehicles</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles() 
        {
            //Get all vehicles and with the make foreign key included
            var vehicles = _context.Vehicle.Include(p => p.make).AsEnumerable();

            if (vehicles == null) 
            {
                return NotFound();
            }

            return Ok(vehicles);
        }

        /// <summary>
        /// Get specific vehicle
        /// </summary>
        /// <param name="lplateNum">LPlate key of vehicle to get</param>
        /// <returns>Vehicle record</returns>
        [HttpGet("{lplateNum}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(string lplateNum) 
        {
            //Get Vehicle that matches the lplate
            var vehicle = await _context.Vehicle.Include(p => p.make).Where(v => v.licenseNum == lplateNum).FirstOrDefaultAsync();

            if(vehicle == null) 
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        /// <summary>
        /// Get Vehicles that are filtered
        /// </summary>
        /// <param name="filter">Contains the multiple filters</param>
        /// <returns>List of filtered vehicles</returns>
        [HttpPost("Filtered")]
        public ActionResult<IEnumerable<Vehicle>> GetFilteredVehicles([FromBody]APIFilter filter) 
        {
            //Get all vehicles
            var vehicles = _context.Vehicle.Include(v => v.make).AsEnumerable();
            
            if (vehicles == null) 
            {
                return NotFound();
            }

            //If filter for make not null
            if(filter.makeID != Guid.Empty) 
            {
                //Filter
                vehicles = vehicles.Where(v => v.makeID == filter.makeID);
            }
            //If filter for state not null
            if (filter.state != null && filter.state != "All") 
            {
                //Filter
                vehicles = vehicles.Where(v => v.state == filter.state);
            }
            //If filter for lplate not null
            if (filter.lPlate != null) 
            {
                //Filter
                vehicles = vehicles.Where(v => v.licenseNum.Contains(filter.lPlate, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(vehicles);
        }

        /// <summary>
        /// Insert vehicle into db
        /// </summary>
        /// <param name="dto">vehicle record to be added</param>
        /// <returns>Http Response</returns>
        [HttpPost("Insert")]
        public async Task<ActionResult> InsertVehicle([FromBody]Vehicle dto) 
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                //Add and save db
                _context.Vehicle.Add(dto);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates existing vehicle record in the db
        /// </summary>
        /// <param name="dto">vehicle record to be updated</param>
        /// <returns>Http Response</returns>
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