using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnAAPI.Models
{
    public class QnAItemContext : DbContext
    {
        public QnAItemContext(DbContextOptions<QnAItemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<QnAItem> QnAItems { get; set; }
    }
}
