using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            //var kategoriler = db.Kategoriler.ToList();
            var kategoriler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kategoriler kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(Kategoriler kategori)
        {
            var ktgr = db.Kategoriler.Find(kategori.KategoriID);
            ktgr.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}