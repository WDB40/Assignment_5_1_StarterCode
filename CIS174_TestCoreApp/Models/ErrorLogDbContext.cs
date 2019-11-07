using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class ErrorLogDbContext : DbContext
    {
        public ErrorLogDbContext(DbContextOptions<ErrorLogDbContext> options) : base(options) { }

        public DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
