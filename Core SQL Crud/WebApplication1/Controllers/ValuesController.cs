using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private NORTHWNDContext _context;
        public ValuesController(NORTHWNDContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public object Get()
        {
            var queryString = Request.Query;
           
            int skip = Convert.ToInt32(queryString["$skip"]);
            int take = Convert.ToInt32(queryString["$top"]);
            var data = _context.Orders.ToList();
            if (queryString["$select"].Count() > 0)
            {
                var empdata = _context.Orders.Select(c => c.EmployeeID).Distinct().ToList();
                return empdata;
            }
            return new { Items = _context.Orders.Skip(skip).Take(take), Count = data.Count() };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
