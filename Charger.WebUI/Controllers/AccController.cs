using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Charger.WebUI.Infrastructure.Abstract;
using Charger.WebUI.Models;

namespace Charger.WebUI.Controllers
{
    public class AccController : Controller
    {
        IAuthProv iAuthProv;
        public AccController(IAuthProv iAuthProv)
        {
            this.iAuthProv = iAuthProv;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (iAuthProv.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub niepoprawne hasło."); 
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }

}
