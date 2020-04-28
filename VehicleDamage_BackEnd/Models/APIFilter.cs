using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleDamage_BackEnd.Models
{
    public class APIFilter
    {
        public string state { get; set; }

        public Guid makeID { get; set; }

        public string lPlate { get; set; }
    }
}
