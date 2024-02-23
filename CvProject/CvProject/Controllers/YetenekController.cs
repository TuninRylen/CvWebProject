using CvProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Repositories;

namespace CvProject.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<TblYeteneklerim> repo = new GenericRepository<TblYeteneklerim>();

        public ActionResult Index()
        {
            var yeteneklerim = repo.List();
            return View(yeteneklerim);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim T)
        {
            repo.Add(T);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            repo.Delete(yetenek);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekDüzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
            
        }

        [HttpPost]
        public ActionResult YetenekDüzenle(TblYeteneklerim T)
        {
            var y = repo.Find(x => x.ID == T.ID);
            y.Yetenek = T.Yetenek;
            y.Oran = T.Oran;
            repo.Update(y);
            return RedirectToAction("Index");
        }
    }
}