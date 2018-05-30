using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Domm.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public int CustomerId { set; get; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        [ForeignKey("CustomerId")]
        public IEnumerable<ChOperation> Operations { set; get; }
    }
}
