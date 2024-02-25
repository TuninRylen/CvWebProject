using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class IletisimController : Controller
    {

        GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();

        public ActionResult Index()
        {
            var iletisim = repo.List();
            return View(iletisim);
        }
    }
}