
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AItemAPI.Models
{
    public class AItemContext : DbContext
    {
        public AItemContext(DbContextOptions<AItemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<AItem> AItems { get; set; }
    }
}
