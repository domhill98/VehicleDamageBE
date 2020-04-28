using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleDamage_BackEnd_Data
{
    public class Make
    {
        [Key]
        public Guid id { get; set; }

        public string name { get; set; }
    }
}
