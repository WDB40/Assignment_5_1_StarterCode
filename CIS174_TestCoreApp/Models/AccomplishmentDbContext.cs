using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class AccomplishmentDbContext : DbContext
    {
        public AccomplishmentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
