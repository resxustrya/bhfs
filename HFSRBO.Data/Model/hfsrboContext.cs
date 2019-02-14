using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace HFSRBO.Data
{
    class hfsrboContext : DbContext
    {
        public hfsrboContext() : base("name=hfsrbo")
        { }
        public DbSet<complaints> _complaints { get; set; }
    } 
}
