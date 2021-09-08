using Microsoft.EntityFrameworkCore;
using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF
{
    public class RepoDbContext:DbContext
    {
        public RepoDbContext(DbContextOptions<RepoDbContext> options):base(options)
        {

        }

       

        public DbSet<client> clients { get; set; }
        public DbSet<Calls> calls { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
