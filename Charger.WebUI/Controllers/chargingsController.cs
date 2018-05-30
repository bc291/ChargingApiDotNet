using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Charger.Domm.Abstract;
using Charger.Domm.Entities;

namespace Charger.WebUI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class chargingsController : ApiController
    {
        private IApiRepository iApiRepository;

        public chargingsController(IApiRepository iApiRepository)
        {
            this.iApiRepository = iApiRepository;
        }

        // GET api/<controller>
        public IEnumerable<ChOperation> Get()
        {
            return iApiRepository.GetChargings();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody]ChOperation chOperation)
        {
            iApiRepository.InsertCharging(chOperation);
            return "added" + chOperation.id;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return iApiRepository.DeleteCharging(id);
        }
    }
}