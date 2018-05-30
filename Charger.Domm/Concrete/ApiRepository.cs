using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;
using Newtonsoft.Json;

namespace Charger.Domm.Concrete
{
    public class ApiRepository : IApiRepository
    {
        private IOperationsRepository iOperationsRepository;

        public ApiRepository(IOperationsRepository iOperationsRepository)
        {
            this.iOperationsRepository = iOperationsRepository;
        }


        public IEnumerable<ChOperation> GetChargings()
        {
            return iOperationsRepository.ChOperations;
        }

        public void InsertCharging(ChOperation chOperation)
        {
            var context = iOperationsRepository.DbGetContext();
            context.ChOperations.Add(chOperation);
            context.SaveChanges();
        }

        public ChOperation SaveCharging(ChOperation chOperation)
        {
            var context = iOperationsRepository.DbGetContext();
            ChOperation chOperationSwap = context.ChOperations.Find(chOperation.id);
            if (chOperationSwap != null)
            {
                chOperationSwap.carModel = chOperation.carModel;
                chOperationSwap.cost = chOperation.cost;
                chOperationSwap.averagePower = chOperation.averagePower;
                chOperationSwap.capacityCharged = chOperation.capacityCharged;
                chOperationSwap.dateAndTime = chOperation.dateAndTime;
                chOperationSwap.elapsedTime = chOperation.elapsedTime;
                chOperationSwap.initialCapacity = chOperation.initialCapacity;
            }

            context.SaveChanges();
            return chOperationSwap;
        }

        public bool DeleteCharging(int id)
        {
            var context = iOperationsRepository.DbGetContext();
            ChOperation chOperation = context.ChOperations.Find(id);
            if (chOperation != null)
            {             
                context.ChOperations.Remove(chOperation);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
