using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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









    }
}