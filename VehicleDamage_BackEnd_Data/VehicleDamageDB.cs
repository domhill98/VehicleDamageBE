using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleDamage_BackEnd_Data
{
    public class VehicleDamageDB : DbContext
    {
        public DbSet<Vehicle> Vehicle { get; set; }

        public DbSet<ClockHistory> ClockHistory { get; set; }

        public DbSet<DamageHistory> DamageHistory { get; set; }

        public DbSet<Make> Make { get; set; }

        public VehicleDamageDB(DbContextOptions<VehicleDamageDB> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Make>(x =>
            {
                x.Property(m => m.id).IsRequired();
                x.Property(m => m.name).IsRequired();
            });

            modelBuilder.Entity<ClockHistory>(x =>
            {
                x.Property(c => c.Id).IsRequired();
                x.Property(c => c.lplateNum).IsRequired();
                x.Property(c => c.state).IsRequired();
                x.Property(c => c.time).IsRequired();
                x.Property(c => c.driverID).IsRequired();
            });


            modelBuilder.Entity<DamageHistory>(x => {
                x.Property(d => d.Id).IsRequired();
                x.Property(d => d.lplateNum).IsRequired();
                x.Property(d => d.resolved).IsRequired();
                x.Property(d => d.state).IsRequired();
                x.Property(p => p.time).IsRequired();
                x.Property(p => p.driverID).IsRequired();
            });

            modelBuilder.Entity<Vehicle>(x => {
                x.Property(v => v.licenseNum).IsRequired();
                x.Property(v => v.model).IsRequired();
                x.Property(v => v.active).IsRequired();
                x.Property(v => v.state).IsRequired();
                x.HasOne(v => v.make).WithMany()
                                    .HasForeignKey(m => m.makeID)
                                    .IsRequired();
            });


        }


    }
}
