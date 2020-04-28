using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDamage_BackEnd_Data
{
    public static class VehicleDamageDBInitialiser
    {

        public static async Task SeedTestData(VehicleDamageDB context, IServiceProvider services)
        {
            if (context.Vehicle.Any())
            {
                //DB already seeded
                return;
            }

            var makes = new List<Make> 
            {
                new Make{id = Guid.Parse("2648f895-848f-4163-b9b8-e77c8b48a741"), name = "Vauxhall" },
                new Make{id = Guid.Parse("8d3b3b08-1eba-4974-82d9-df7c09615376"), name = "Ford" },
                new Make{id = Guid.Parse("82a3d9a6-4945-45d1-86f4-af909f0e4bb1"), name = "Ferrari" }
            };
            makes.ForEach(m => context.Make.Add(m));

            var clockHistories = new List<ClockHistory> 
            {
                new ClockHistory{ Id = Guid.Parse("860ee42c-5626-4e6f-b801-2d06173bca61"), driverID = Guid.NewGuid(), lplateNum = "1234", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("36444a8f-a6fd-403f-8e8c-674a06602c18"), driverID = Guid.NewGuid(), lplateNum = "1234", state = "In", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("38bf7bcc-890e-4fec-8cfe-90cc65180d8c"), driverID = Guid.NewGuid(), lplateNum = "2345", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), driverID = Guid.NewGuid(), lplateNum = "3456", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("7a63174f-8896-4268-8758-981277d37b9d"), driverID = Guid.NewGuid(), lplateNum = "4567", state = "Out", time = DateTime.Now }
            };
            clockHistories.ForEach(c => context.ClockHistory.Add(c));

            await context.SaveChangesAsync();

            var damageHistories = new List<DamageHistory> 
            {
                new DamageHistory{ Id = Guid.NewGuid(), driverID = Guid.NewGuid(), lplateNum = "1234", state = "Damaged", time = DateTime.Now, resolved = true},
                new DamageHistory{ Id = Guid.NewGuid(), driverID = Guid.NewGuid(), lplateNum = "2345", state = "Pending", time = DateTime.Now, resolved = false},
                new DamageHistory{ Id = Guid.NewGuid(), driverID = Guid.NewGuid(), lplateNum = "2345", state = "Damaged", time = DateTime.Now, resolved = true},
                new DamageHistory{ Id = Guid.NewGuid(), driverID = Guid.NewGuid(), lplateNum = "4567", state = "Damaged", time = DateTime.Now, resolved = true}
            };
            damageHistories.ForEach(d => context.DamageHistory.Add(d));

            await context.SaveChangesAsync();

            var vehicles = new List<Vehicle> 
            {
                new Vehicle{ licenseNum = "1234", makeID = Guid.Parse("2648f895-848f-4163-b9b8-e77c8b48a741"), make = makes[0], model = "Corsa", colour = "Red", state = "In", active = true },
                new Vehicle{ licenseNum = "2345", makeID = Guid.Parse("2648f895-848f-4163-b9b8-e77c8b48a741"), make = makes[0], model = "Corsa", colour = "Silver", state = "Out", active = true },
                new Vehicle{ licenseNum = "3456", makeID = Guid.Parse("8d3b3b08-1eba-4974-82d9-df7c09615376"), make = makes[1], model = "Fiesta", colour = "Blue", state = "Out", active = true },
                new Vehicle{ licenseNum = "4567", makeID = Guid.Parse("8d3b3b08-1eba-4974-82d9-df7c09615376"), make = makes[1], model = "Fiesta", colour = "Black", state = "In", active = true },
                new Vehicle{ licenseNum = "5678", makeID = Guid.Parse("2648f895-848f-4163-b9b8-e77c8b48a741"), make = makes[3], model = "Fast", colour = "Green", state = "In", active = false }
            };
            vehicles.ForEach(v => context.Vehicle.Add(v));


            await context.SaveChangesAsync();
        }

    }
}
