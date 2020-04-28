using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDamage_BackEnd.Data
{
    public static class VehicleDamageDBInitialiser
    {

        public static async Task SeedTestData(VehicleDamageDB context, IServiceProvider services)
        {
            if (context.Vehicles.Any())
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
            makes.ForEach(m => context.Makes.Add(m));

            var clockHistories = new List<ClockHistory> 
            {
                new ClockHistory{ Id = Guid.Parse("860ee42c-5626-4e6f-b801-2d06173bca61"), driverID = Guid.NewGuid(), lplateNum = "1234", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("36444a8f-a6fd-403f-8e8c-674a06602c18"), driverID = Guid.NewGuid(), lplateNum = "1234", state = "In", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("38bf7bcc-890e-4fec-8cfe-90cc65180d8c"), driverID = Guid.NewGuid(), lplateNum = "2345", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), driverID = Guid.NewGuid(), lplateNum = "3456", state = "Out", time = DateTime.Now },
                new ClockHistory{ Id = Guid.Parse("7a63174f-8896-4268-8758-981277d37b9d"), driverID = Guid.NewGuid(), lplateNum = "4567", state = "Out", time = DateTime.Now }
            };

            await context.SaveChangesAsync();







            var reviews = new List<Review>
            {
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), ReviewerId = Guid.NewGuid(), ReviewerName = "Bob", Rating = 0, Description = "Very Poor", Show = false },
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), ReviewerId = Guid.NewGuid(), ReviewerName = "Bill", Rating = 1, Description = "Poor", Show = true },
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("423edc63-1373-41e4-8655-c1b9671afeb9"), ReviewerId = Guid.NewGuid(), ReviewerName = "Bernie", Rating = 1, Description = "Poor", Show = true },
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("bc12c678-93f9-43af-9379-f6e7cdf91fde"), ReviewerId = Guid.NewGuid(), ReviewerName = "Byrt", Rating = 5, Description = "Crackin", Show = true },
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("bc12c678-93f9-43af-9379-f6e7cdf91fde"), ReviewerId = Guid.NewGuid(), ReviewerName = "Bart", Rating = 5, Description = "Spot on", Show = true },
                new Review { Id = Guid.NewGuid(), ProductId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), ReviewerId = Guid.NewGuid(), ReviewerName = "Biff", Rating = 5, Description = "Would buy again", Show = true }
            };
            reviews.ForEach(r => context.Reviews.Add(r));

            await context.SaveChangesAsync();



            var orders = new List<OrderHistory>
            {
                new OrderHistory { Id = Guid.NewGuid(), productId = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), userId = Guid.NewGuid() },
                new OrderHistory { Id = Guid.NewGuid(), productId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), userId = Guid.NewGuid() },
                new OrderHistory { Id = Guid.NewGuid(), productId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), userId = Guid.NewGuid() },
                new OrderHistory { Id = Guid.NewGuid(), productId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), userId = Guid.NewGuid() },
                new OrderHistory { Id = Guid.NewGuid(), productId = Guid.Parse("423edc63-1373-41e4-8655-c1b9671afeb9"), userId = Guid.NewGuid() }
            };
            orders.ForEach(o => context.OrderHistory.Add(o));

            await context.SaveChangesAsync();



            var resell = new List<ResellHistory>
            {
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), userId = Guid.NewGuid(), oldPrice = 1.0m, newPrice = 1.2m, created = DateTime.Now},
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("604f7632-4942-49b7-9538-8675787b339c"), userId = Guid.NewGuid(), oldPrice = 1.2m, newPrice = 3.0m, created = DateTime.Now},
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), userId = Guid.NewGuid(), oldPrice = 0.5m, newPrice = 0.75m, created = DateTime.Now},
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("a0873045-6c9c-4094-943b-f82c86932135"), userId = Guid.NewGuid(), oldPrice = 0.75m, newPrice = 1.0m, created = DateTime.Now},
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("bc12c678-93f9-43af-9379-f6e7cdf91fde"), userId = Guid.NewGuid(), oldPrice = 1.0m, newPrice = 0.5m, created = DateTime.Now},
                new ResellHistory { Id = Guid.NewGuid(), productId = Guid.Parse("bc12c678-93f9-43af-9379-f6e7cdf91fde"), userId = Guid.NewGuid(), oldPrice = 0.5m, newPrice = 0.4m, created = DateTime.Now}
            };
            resell.ForEach(re => context.ResellHistory.Add(re));



            await context.SaveChangesAsync();
        }













    }
}
