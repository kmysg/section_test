using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace section_test.Models
{
    public class TestApiContext : DbContext
    {
        public TestApiContext(DbContextOptions<TestApiContext> options)
                : base(options)
        {
        }

        public DbSet<Process> Processes { get; set; }
    }

}
