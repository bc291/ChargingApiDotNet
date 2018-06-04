using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;

namespace Charger.Domm.Concrete
{
   public class EFOperationsRepository : IOperationsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<ChOperation> ChOperations
        {
            get { return context.ChOperations; }
        }

        public IEnumerable<Customer> Customers
        {
            get { return context.Customers; }
        }

        public EFDbContext DbGetContext()
        {
            return context;
        }

        
    }
}
