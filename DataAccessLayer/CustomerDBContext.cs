using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.DataAccessLayer
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }


        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Mathew",
                    BusinessName = "OnlineService",
                    DateofBirth = Convert.ToDateTime("1960-01-15"),
                    CreatedDate = System.DateTime.Now
                },
                 new Customer
                 {
                     CustomerId = 2,
                     FirstName = "Smith",
                     LastName = "Williams",
                     BusinessName = "Hotel",
                     DateofBirth = Convert.ToDateTime("2000-10-05"),
                     CreatedDate = System.DateTime.Now
                 }
                 );
        }
    }
}
