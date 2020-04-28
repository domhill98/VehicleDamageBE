using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleDamage_BackEnd.Data
{
    public class DamageHistory
    {
        [Key]
        public Guid Id { get; set; }

        public Guid driverID { get; set; }

        public DateTime time { get; set; }

        public string lplateNum { get; set; }

        public string state { get; set; }

        public bool resolved { get; set; }
    }
}
