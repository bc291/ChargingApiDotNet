using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;

namespace Charger.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IApiRepository iApiRepository;

        public AdminController(IApiRepository iApiRepository)
        {
            this.iApiRepository = iApiRepository;
        }

        public ActionResult Index()
        {
            return View(iApiRepository.GetChargings());
        }

        public ViewResult Edit(int id)
        {
            ChOperation chOperation = iApiRepository.GetChargings().FirstOrDefault(x => x.id == id);
            return View(chOperation);
        }

        [HttpPost]
        public ActionResult Edit(ChOperation chOperation)
        {
            if (ModelState.IsValid)
            {
                iApiRepository.SaveCharging(chOperation);
                TempData["message"] = string.Format("Zapisano {0} ", chOperation.carModel);
                return RedirectToAction("Index");
            }

            return View(chOperation);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool isDeleted = iApiRepository.DeleteCharging(id);
            if (isDeleted)
            {
                TempData["message"] = string.Format("Usunięto operację o id: {0}", id);
            }

            return RedirectToAction("Index");
        }
    }
}