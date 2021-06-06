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

        public DbSet<RestaurentMenu> RestaurentMenus { get; set; }

        public DbSet<Orders> Orders { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source='.'; Database=FudGDb; Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuring RestarentMenu Entity

            /*setting Composite PrimaryKey Constraint */
            modelBuilder.Entity<RestaurentMenu>().HasKey(sc => new { sc.RestaurentId, sc.FoodId });
            /*Setting Foreign Key Constraint  To the Food Table*/
            modelBuilder.Entity<RestaurentMenu>()
            .HasOne<Food>(sc => sc.Food)
            .WithMany(s => s.RestaurentMenus)
            .HasForeignKey(sc => sc.FoodId);

            /*Setting Foreign Key Constraint to the Restaurent Table  */
            modelBuilder.Entity<RestaurentMenu>()
            .HasOne<Restaurent>(sc => sc.Restaurent)
            .WithMany(s => s.RestaurentMenus)
            .HasForeignKey(sc => sc.RestaurentId);


            /* Configuring The Orders Table */
            modelBuilder.Entity<Orders>().HasKey(sc => new { sc.CustomerId, sc.RestaurentId, sc.FoodId });
            /* Defining The Foriegn Key Constraint */
            modelBuilder.Entity<Orders>()
            .HasOne<Customer>(sc => sc.Customer)
            .WithMany(s => s.Orders)
            .HasForeignKey(sc => sc.CustomerId);

            modelBuilder.Entity<Orders>()
            .HasOne<Restaurent>(sc => sc.Restaurent)
            .WithMany(s => s.Orders)
            .HasForeignKey(sc => sc.RestaurentId);

            modelBuilder.Entity<Orders>()
            .HasOne<Food>(sc => sc.Food)
            .WithMany(s => s.Orders)
            .HasForeignKey(sc => sc.FoodId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
