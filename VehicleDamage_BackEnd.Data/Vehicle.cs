using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleDamage_BackEnd.Data
{
    public class Vehicle
    {
        public string licenseNum { get; set; }

        public string model { get; set; }

        public Guid makeID { get; set; }

        public Make make { get; set; }

        public string colour { get; set; }

        public string state { get; set; }

        public bool active { get; set; }

    }
}
