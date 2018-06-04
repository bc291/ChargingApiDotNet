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
        IEnumerable<Customer> GetCustomers();
        void InsertCharging(ChOperation chOperation);
        ChOperation SaveCharging(ChOperation chOperation);
        Customer SaveCustomer(Customer customer);
        bool DeleteCharging(int id);
        bool DeleteCustomer(int customerId);
    }
}
