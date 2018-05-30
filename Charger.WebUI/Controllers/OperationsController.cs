using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;
using Charger.WebUI.Models;

namespace Charger.WebUI.Controllers
{
    public class OperationsController : Controller
    {
        private IOperationsRepository iOperationsRepository;
        private IApiRepository iApiRepository;
        public int PageSize = 4;

        public OperationsController(IOperationsRepository iOperationsRepository, IApiRepository iApiRepository)
        {
            this.iOperationsRepository = iOperationsRepository;
            this.iApiRepository = iApiRepository;
        }

        public ViewResult Index(string carModel = "all", int page = 1)
        {
            if (carModel == "all")
            {
                OperationListModel operationListModel2 = new OperationListModel()
                {
                    Operations = iApiRepository.GetChargings().OrderBy(x => x.id).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = iApiRepository.GetChargings().Count()
                    },
                    CurrentCarModel = carModel
                };
                return View(operationListModel2);
            }

            OperationListModel operationListModel = new OperationListModel()
                {
                    Operations = iApiRepository.GetChargings().Where(x => x.carModel == null || x.carModel == carModel).OrderBy(x => x.id).Skip((page - 1) * PageSize).Take(PageSize),
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = carModel == null ? iApiRepository.GetChargings().Count() :
                            iApiRepository.GetChargings().Count(x => x.carModel == carModel)
                    },
                    CurrentCarModel = carModel
                };
                return View(operationListModel);
        }


     
    }
}