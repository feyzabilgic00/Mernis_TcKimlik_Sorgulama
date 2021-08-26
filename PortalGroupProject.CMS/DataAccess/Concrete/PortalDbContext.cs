using Microsoft.EntityFrameworkCore;
using PortalGroupProject.CMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGroupProject.CMS.DataAccess.Concrete
{
    public class PortalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PortalGroupDb;Trusted_Connection=true;");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
