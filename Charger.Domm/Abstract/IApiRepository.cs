using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charger.Domm.Entities;

namespace Charger.Domm.Abstract
{
    public interface IApiRepository
    {
        IEnumerable<ChOperation> GetChargings();
        void InsertCharging(ChOperation chOperation);
        ChOperation SaveCharging(ChOperation chOperation);
        bool DeleteCharging(int id);
    }
}
