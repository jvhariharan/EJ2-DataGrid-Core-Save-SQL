using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Syncfusion.EJ2;
using System.Collections;
using Newtonsoft.Json;
using System.Web;
using Syncfusion.EJ2;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Reflection;
using Syncfusion.EJ2;
using Syncfusion.EJ2;
using Syncfusion.EJ2;
using Syncfusion.EJ2.Base;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private NORTHWNDContext _context;

        public HomeController(NORTHWNDContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult TelecomDataSource([FromBody]DataManagerRequest dataManager)
        {
            IEnumerable data = _context.Orders.ToList();
            DataOperations operation = new DataOperations();
            int count = data.Cast<Orders>().Count();
            if (dataManager.Skip != 0)
            {
                data = operation.PerformSkip(data, dataManager.Skip);
            }
            if (dataManager.Take != 0)
            {
                data = operation.PerformTake(data, dataManager.Take);
            }
            return Json(new { result = data, count = count });
        }

        

       


        public async Task<ActionResult> Insert([FromBody]CRUDModel<Orders> param)
        {
            _context.Orders.Add(param.Value);
            await _context.SaveChangesAsync();
            return Json(param.Value);

        }
        public async Task<ActionResult> Update([FromBody]CRUDModel<Orders> param)
        {
            _context.Orders.Update(param.Value);
            await _context.SaveChangesAsync();
            return Json(param.Value);
        }
        public async Task<ActionResult>  Delete([FromBody]CRUDModel<Orders> param)
        {
           Orders value = _context.Orders.Where(e => e.OrderID == Int32.Parse(param.Key.ToString())).FirstOrDefault();
            _context.Remove(value);
            await _context.SaveChangesAsync();
            return Json(value);
        }

    }
}
