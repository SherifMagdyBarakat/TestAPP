using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TestAPP.Models
{
    public class AppDBContext: IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }


    }
}
