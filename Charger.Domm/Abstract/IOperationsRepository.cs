using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charger.Domm.Concrete;
using Charger.Domm.Entities;

namespace Charger.Domm.Abstract
{
   public interface IOperationsRepository
    {
        IEnumerable<ChOperation> ChOperations { get; }
        EFDbContext DbGetContext();
    }
}
