using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();

        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim T)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }

            repo.Add(T);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.Delete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim T)
        {
            var egitim = repo.Find(x => x.ID == T.ID);
            egitim.Baslik = T.Baslik;
            egitim.AltBaslik1 = T.AltBaslik1;
            egitim.AltBaslik2 = T.AltBaslik2;
            egitim.Tarih = T.Tarih;
            egitim.GNO = T.GNO;
            repo.Update(egitim);
            return RedirectToAction("Index");
        }
    }
}