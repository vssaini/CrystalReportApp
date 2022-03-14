using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalReportApp.Models;

namespace CrystalReportApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCustomerList()
        {
            // Instructions:
            // Use Northwind database
            // Follow article at https://www.tektutorialshub.com/crystal-reports/create-crystal-reports-in-asp-net-mvc/

            var db = new NorthwindEntities();

            var customers = db.Customers.Take(20).ToList();

            var cusRpt = new CustomerList();
            cusRpt.Load();
            cusRpt.SetDataSource(customers);

            var stream = cusRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");
        }
    }
}