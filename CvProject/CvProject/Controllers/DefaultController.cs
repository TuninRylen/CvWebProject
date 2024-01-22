using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models.Entity;


namespace CvProject.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
    }
}