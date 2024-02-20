using CvProject.Models.Entity;
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

        [HttpGet]
        public ActionResult DeneyimEkle() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyimlerim p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            TblDeneyimlerim T = repo.Find(x=>x.ID == id);
            repo.Delete(T);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id) 
        {
            TblDeneyimlerim T = repo.Find(x => x.ID == id);
            return View(T);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyimlerim p) 
        {
            TblDeneyimlerim T = repo.Find(x => x.ID == p.ID);
            T.Aciklama = p.Aciklama;
            T.Tarih = p.Tarih;
            T.Baslik = p.Baslik;
            T.AltBaslik = p.AltBaslik;  
            repo.Update(T);
            return RedirectToAction("Index");

        }
    }
}