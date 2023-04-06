using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IO;
using DAL;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Designproject> Designprojects { get; set; }
        public DbSet<Jobtitle> Jobtitles { get; set; }
        public DbSet<Orderforobject> Orderforobjects { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Typeofwork> Typeofworks { get; set; }
        public DbSet<Workcatalog> Workcatalogs { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
