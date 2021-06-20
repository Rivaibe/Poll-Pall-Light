using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollAPI.Models
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollCurrentResult> PollCurrentResults { get; set; }
        public DbSet<PollResult> PollResults { get; set; }
        
        public DbSet<PollVariables> PollVariables { get; set; }
    }
}
