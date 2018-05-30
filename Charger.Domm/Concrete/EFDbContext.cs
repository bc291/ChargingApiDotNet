using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charger.Domm.Entities;

namespace Charger.Domm.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<ChOperation> ChOperations { set; get; }

        public EFDbContext() :base("EFDbContext")
        {
        }
    }
}
