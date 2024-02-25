using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class HobilerimController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();

        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim T)
        {
            repo.Add(T);  
            return RedirectToAction("Index");
        }
    }
}