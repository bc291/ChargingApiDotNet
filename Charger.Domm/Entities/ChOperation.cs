using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Charger.Domm.Entities
{
    [Table("ChargOperations")]
    public class ChOperation
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        [Required(ErrorMessage = "Proszę podać model samochodu.")]
        [Display(Name = "Model samochodu")]
        public string carModel { get; set; }
        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Proszę podać ilość dostarczonych kWh")]
        [Display(Name = "Naładowana pojemność")]
        public float capacityCharged { get; set; }
        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Proszę podać średnią moc ładowania")]
        [Display(Name = "Średnia moc ładowania")]
        public float averagePower { get; set; }
        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Proszę podać koszt ładowania.")]
        [Display(Name = "Koszt ładowania")]
        public float cost { get; set; }
        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Proszę podać średnią czas ładowania")]
        [Display(Name = "Czas ładowania (minuty)")]
        public float elapsedTime { get; set; }
        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Proszę podać pojemność początkową")]
        [Display(Name = "Pojemność początkowa")]
        public float initialCapacity { get; set; }
        [Required(ErrorMessage = "Proszę podać czas zakończenia ładowania")]
        [Display(Name = "Czas zakończenia ładowania")]
        public string dateAndTime { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { set; get; }
    }
}
