using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();

        // GET: Deneyim
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}