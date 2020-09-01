using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalReport_ASP.NetMVC.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace CrystalReport_ASP.NetMVC.Controllers
{
    public class HomeController : Controller
    {
        employeeDBEntities db = new employeeDBEntities();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        public ActionResult extendReport()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "empReportCR.rpt"));
            rd.SetDataSource(db.Employees.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream st = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                st.Seek(0, SeekOrigin.Begin);
                return File(st, "Application/pdf", "empList_report.pdf");
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
