using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

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
        
        public ActionResult HobiSil(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            repo.Delete(hobi);
            return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult HobiGuncelle(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }

        [HttpPost]
        public ActionResult HobiGuncelle(TblHobilerim T)
        {
            var hobi = repo.Find(x => x.ID == T.ID);
            hobi.Aciklama1 = T.Aciklama1;
            hobi.Aciklama2 = T.Aciklama2;
            repo.Update(hobi);
            return RedirectToAction("Index");
        }


    }
}