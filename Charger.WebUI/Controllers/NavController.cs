using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charger.Domm.Abstract;

namespace Charger.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IApiRepository iApiRepository;

        public NavController(IApiRepository iApiRepository)
        {
            this.iApiRepository = iApiRepository;
        }

        // GET: Nav
        public PartialViewResult Menu(string carModel = "all")
        {
            ViewBag.SelectedCarModel = carModel;
            IEnumerable<string> carModelList =
                iApiRepository.GetChargings().Select(x => x.carModel).Distinct().OrderBy(x => x);
            return PartialView(carModelList);
        }
    }
}