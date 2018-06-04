using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Charger.Domm.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [HiddenInput(DisplayValue = false)]
        public int CustomerId { set; get; }
        [Required(ErrorMessage = "Proszę podać imię i nazwisko")]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proszę podać imię")]
        [Display(Name = "Imię i nazwisko")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Proszę podać adres")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [HiddenInput(DisplayValue = false)]
        [ForeignKey("CustomerId")]
        public IEnumerable<ChOperation> Operations { set; get; }
    }
}
