using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poll_Pall_Light.Models
{
    public class PollContext : DbContext
    {
        public PollContext(DbContextOptions<PollContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Poll> Polls { get; set; }
    }
}
