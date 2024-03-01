using CvProject.Models.Entity;
using CvProject.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvProject.Controllers
{
    public class SosyalMedyaController : Controller
    {
        
        GenericRepository<TblSosyalmedya> repo = new GenericRepository<TblSosyalmedya>();

        public ActionResult Index()
        {
            var sosyalmedya = repo.List();
            return View(sosyalmedya);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalmedya T)
        {
            repo.Add(T);
            return RedirectToAction("Index");
        }

        public ActionResult Aktiflestir(int id)
        {
            var medya = repo.Find(x=> x.ID == id);
            medya.Durum = true;
            repo.Update(medya);
            return RedirectToAction("Index");
        }

        public ActionResult Pasiflestir(int id)
        {
            var medya = repo.Find(x => x.ID == id);
            medya.Durum = false;
            repo.Update(medya);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var medya = repo.Find(x => x.ID == id);
            repo.Delete(medya);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sosyalmedya = repo.Find(x=> x.ID == id);
            return View(sosyalmedya);
        }

        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalmedya T)
        {
            var sosyalmedya = repo.Find(x => x.ID == T.ID);
            sosyalmedya.Ad = T.Ad;
            sosyalmedya.Link = T.Link;
            sosyalmedya.Ikon = T.Ikon;
            repo.Update(sosyalmedya);
            return RedirectToAction("Index");
        }



    }
}