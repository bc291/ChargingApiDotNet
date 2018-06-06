using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;
using Charger.WebUI.Models;

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
            return View();
        }

        public ActionResult OperationsIndex()
        {
            return View(iApiRepository.GetChargings());
        }

        public ActionResult CustomersIndex()
        {
            return View(iApiRepository.GetCustomers());
        }

        public ViewResult OperationsEdit(int id)
        {
            ChOperation chOperation = iApiRepository.GetChargings().FirstOrDefault(x => x.id == id);
            return View(chOperation);
        }

        public ViewResult EditCustomer(int CustomerId)
        {
            Customer customer = iApiRepository.GetCustomers().FirstOrDefault(x => x.CustomerId == CustomerId);
            return View(customer);
        }

        [HttpPost]
        public ActionResult OperationsEdit(ChOperation chOperation)
        { 
            if (ModelState.IsValid)
            {
                iApiRepository.SaveCharging(chOperation);
                TempData["message"] = string.Format("Zapisano {0} ", chOperation.carModel);
                return RedirectToAction("OperationsIndex");
            }

            return View(chOperation);
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                iApiRepository.SaveCustomer(customer);
                TempData["message"] = $"Zapisano klienta {customer.FullName}";
                return RedirectToAction("CustomersIndex");
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult OperationsDelete(int id)
        {
            bool isDeleted = iApiRepository.DeleteCharging(id);
            if (isDeleted)
            {
                TempData["message"] = string.Format("Usunięto operację o id: {0}", id);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int CustomerId)
        {
            bool isDeleted = iApiRepository.DeleteCustomer(CustomerId);
            if (isDeleted)
            {
                TempData["message"] = $"Usunięto klienta o id {CustomerId}";
            }

            return RedirectToAction("CustomersIndex");
        }

        public ViewResult CreateCustomer()
        {
            return View("EditCustomer", new Customer());

        }
    }
}