using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EO.Pdf.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    [HandleError]
    public class DemoController : Controller
    {
        public ActionResult Input()
        {
            AddressModel m = new AddressModel();
            m.ExportToPDF = true;
            return View(m);
        }

        [HttpPost]
        [EO.Pdf.Mvc.RenderAsPDF(AutoConvert=false)]
        public ActionResult Input(AddressModel m)
        {
            if (m.ExportToPDF)
            {
                MVCToPDF.ResultFileName = "AddressLabel";
                if (m.SaveAsFile)
                    MVCToPDF.SendToClient = false;
                MVCToPDF.RenderAsPDF(new EO.Pdf.PdfDocumentEventHandler(AfterConvert));
            }

            return View("AddressLabel", m);
        }

        private static void AfterConvert(object sender, EO.Pdf.PdfDocumentEventArgs e)
        {
            EO.Pdf.HtmlToPdfResult result = MVCToPDF.Result;
            if (result != null)
            {
                //Uncomment the following line to save the result
                //to a file
                //result.PdfDocument.Save(pdfFileName);
            }
        }
    }
}
