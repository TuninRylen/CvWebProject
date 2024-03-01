﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using CvProject.Models.Entity;


namespace CvProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalmedya.ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TblYeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }

        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TblHobilerim.ToList();
            return PartialView(hobilerim);
        }

        public PartialViewResult Sertifikalarim()
        {
            var sertifikalarim = db.TblSertifikalarım.ToList();
            return PartialView(sertifikalarim);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim T)
        {
            T.Tarih = DateTime.Now;
            db.Tbliletisim.Add(T);
            db.SaveChanges();
            return PartialView();
        }
    }
}