using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<TblAdmin> repo = new GenericRepository<TblAdmin>();   

        public ActionResult Index()
        {

            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(TblAdmin T)
        {

            repo.Add(T);
            return RedirectToAction("Index");
        }


        public ActionResult AdminSil(int id)
        {

            var deladmin = repo.Find(x=> x.ID == id);
            repo.Delete(deladmin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var upadmin = repo.Find(x => x.ID == id);
            return View(upadmin);
        }

        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin T)
        {
            var upadmin = repo.Find(x => x.ID == T.ID);

            upadmin.KullaniciAdi = T.KullaniciAdi;
            upadmin.Sifre = T.Sifre;
            repo.Update(upadmin);
            return RedirectToAction("Index");
        }
    }
}