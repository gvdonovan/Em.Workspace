using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biff.Model;

namespace Biff.Services.Controllers.Api
{
    public class BiffController : ApiController
    {
        // GET: api/Biff
        public IEnumerable<BiffObject> Get()
        {
            var list = new List<BiffObject>
            {
                new BiffObject() {FirstName = "Brian", LastName = "Lagunas"},
                new BiffObject() {FirstName = "Brian", LastName = "Noyes"},
                new BiffObject() {FirstName = "Greg", LastName = "Donovan"},
                new BiffObject() {FirstName = "Skyler", LastName = "Tweedie"},
                new BiffObject() {FirstName = "Chase", LastName = "Anderson"},
                 new BiffObject() {FirstName = "Richard", LastName = "Worth"},
                  new BiffObject() {FirstName = "Joe", LastName = "Adams"},
                   new BiffObject() {FirstName = "Craig", LastName = "Noguez"}
            };

            return list;
        }

        // GET: api/Biff/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Biff
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Biff/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Biff/5
        public void Delete(int id)
        {
        }
    }
}
