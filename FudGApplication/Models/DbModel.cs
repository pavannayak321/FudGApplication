using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudGApplication.Models
{
    public class DbModel : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurent> Restaurents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRestaurentFoodBridge> customerRestaurentFoodBridges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source='.'; Database=FudGDB; Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            /* Bridge Table Confifurations */
            modelBuilder.Entity<CustomerRestaurentFoodBridge>().HasKey(sc => new
            {
                sc.FoodId,
                sc.CustomerId,
                sc.RestaurentId
            });

            modelBuilder.Entity<CustomerRestaurentFoodBridge>()
            .HasOne<Food>(sc => sc.Food)
            .WithMany(s => s.CustomerRestaurentFoodBridges)
            .HasForeignKey(sc => sc.FoodId);

            modelBuilder.Entity<CustomerRestaurentFoodBridge>()
            .HasOne<Restaurent>(sc => sc.Restaurent)
            .WithMany(s => s.CustomerRestaurentFoodBridges)
            .HasForeignKey(sc => sc.RestaurentId);

            modelBuilder.Entity<CustomerRestaurentFoodBridge>()
            .HasOne<Customer>(sc => sc.Customer)
            .WithMany(s => s.CustomerRestaurentFoodBridges)
            .HasForeignKey(sc => sc.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
