using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleDamage_BackEnd.Data;

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












    }
}