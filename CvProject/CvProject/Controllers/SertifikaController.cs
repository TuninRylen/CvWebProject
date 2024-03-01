using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class SertifikaController : Controller
    {

        GenericRepository<TblSertifikalarım> repo = new GenericRepository<TblSertifikalarım>();

        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaEkle() 
        {

            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarım T)
        {
            repo.Add(T);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.Delete(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult SertifikaDuzenle(TblSertifikalarım T)
        {
            var sertifika = repo.Find(x => x.ID == T.ID);
            sertifika.Aciklama = T.Aciklama;
            sertifika.Link = T.Link;
            repo.Update(sertifika);
            return RedirectToAction("Index");
        }
    }
}