using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class HakkımdaController : Controller
    {

        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>(); 

        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }


        [HttpGet]
        public ActionResult HakkımdaGuncelle(int id)
        {
            var upadmin = repo.Find(x => x.ID == id);
            return View(upadmin);
        }

        [HttpPost]
        public ActionResult HakkımdaGuncelle(TblHakkimda T)
        {
            var uphakkımda = repo.Find(x => x.ID == T.ID);

            uphakkımda.Ad = T.Ad;
            uphakkımda.Soyad = T.Soyad;
            uphakkımda.Adres = T.Adres;
            uphakkımda.Telefon = T.Telefon;
            uphakkımda.Mail = T.Mail;
            uphakkımda.Aciklama = T.Aciklama;
            uphakkımda.Resim = T.Resim;

            repo.Update(uphakkımda);
            return RedirectToAction("Index");
        }

    }
}