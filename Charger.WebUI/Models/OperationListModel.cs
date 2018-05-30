using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Charger.Domm.Entities;

namespace Charger.WebUI.Models
{
    public class OperationListModel
    {
        public IEnumerable<ChOperation> Operations { set; get; }
        public PagingInfo PagingInfo { set; get; }
        public string CurrentCarModel { set; get; }
    }
}