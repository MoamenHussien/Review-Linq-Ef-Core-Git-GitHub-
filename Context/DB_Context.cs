using ConsoleApp1.Entities;
using ConsoleApp1.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Context
{
    public class DB_Context : DbContext
    {
        public DbSet<CLsProduct> Product  { get; set; }
        public DbSet<ClsOrder> Order { get; set; }
        public DbSet<ClsCategory> Category { get; set; }
        public DbSet<ClsOrderItem> OrderItem { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string string_command = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build().GetConnectionString("ECommerce");
            optionsBuilder.UseSqlServer(string_command);
            optionsBuilder.AddInterceptors(new SoftDelete());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DB_Context).Assembly);
        }
    }
}
