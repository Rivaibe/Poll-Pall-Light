using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QItemAPI.Models
{
    public class QItemContext : DbContext
    {
        public QItemContext(DbContextOptions<QItemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<QItem> Qitems { get; set; }
    }
}
