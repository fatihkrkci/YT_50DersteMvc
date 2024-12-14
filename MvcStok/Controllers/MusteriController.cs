using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Musteri
        public ActionResult Index(string p)
        {
            var musteriler = from musteri in db.Musteriler select musteri;
            if (!string.IsNullOrEmpty(p))
            {
                musteriler = musteriler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(musteriler.ToList());

            //var musteriler = db.Musteriler.ToList();
            //return View(musteriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Musteriler musteri)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult Guncelle(Musteriler musteri)
        {
            var mstr = db.Musteriler.Find(musteri.MusteriID);
            mstr.MusteriAd = musteri.MusteriAd;
            mstr.MusteriSoyad = musteri.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}