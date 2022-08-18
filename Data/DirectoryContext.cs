using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Models;

namespace PhoneDirectory.Data
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext (DbContextOptions<DirectoryContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees {get; set;}
        public DbSet<Department> Departments {get; set;}
        
        //public DbSet<PhoneDirectory.Models.Employee> Employee { get; set; } = default!;

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }
    }
}
