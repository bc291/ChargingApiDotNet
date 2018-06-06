using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public IEnumerable<Customer> GetCustomers()
        {
            return iOperationsRepository.Customers;
        }

        public void InsertCharging(ChOperation chOperation)
        {
            var context = iOperationsRepository.DbGetContext();
           
            try
            {
                context.ChOperations.Add(chOperation);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }


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

        public Customer SaveCustomer(Customer customer)
        {
            var context = iOperationsRepository.DbGetContext();
            Customer customerSwap = context.Customers.Find(customer.CustomerId);
            if (customerSwap != null)
            {
                customerSwap.Address = customer.Address;
                customerSwap.FullName = customer.FullName;
                customerSwap.Name = customer.Name;
            }
            else
            {
                customerSwap = new Customer() { Name = customer.Name, FullName = customer.FullName, Address = customer.Address };
                context.Customers.Add(customerSwap);
            }
          
            context.SaveChanges();
            return customerSwap;
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

        public bool DeleteCustomer(int customerId)
        {
            var context = iOperationsRepository.DbGetContext();
            Customer customer = context.Customers.Find(customerId);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
