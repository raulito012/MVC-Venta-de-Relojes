using Catalog.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ReportingServices;

namespace Catalog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult imprimir_usuarios()
        {
            using (catalogoEntities dc = new catalogoEntities())
            {
                var v = dc.busca_usuario.ToList();
                return View(v);
            }
        }

        public ActionResult imprimir_articulos()
        {
            using (catalogoEntities dc = new catalogoEntities())
            {
                var v = dc.busca_articulos.ToList();
                return View(v);
            }
        }



        public ActionResult pdf()
        {
            return new Rotativa.ViewAsPdf("imprimir_articulos");
        }



        public ActionResult Repo(string id)
        {
          
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Repo"), "R_articulos.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            List<busca_articulos> cm = new List<busca_articulos>();
            using (catalogoEntities dc = new catalogoEntities())
            {
                cm = dc.busca_articulos.ToList();
            }
            ReportDataSource rd = new ReportDataSource("RelojDataSet2", cm);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }
    }
}