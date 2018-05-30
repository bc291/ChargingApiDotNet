using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Charger.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Proszę podać nazwę użytkownika")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Proszę podać hasło")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}