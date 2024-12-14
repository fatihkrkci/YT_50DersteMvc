using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();

        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> kategoriler = (from kategori in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = kategori.KategoriAd,
                                                    Value = kategori.KategoriID.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler urun)
        {
            var kategori = db.Kategoriler.Where(x => x.KategoriID == urun.Kategoriler.KategoriID).FirstOrDefault();
            urun.Kategoriler = kategori;
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);

            List<SelectListItem> kategoriler = (from kategori in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = kategori.KategoriAd,
                                                    Value = kategori.KategoriID.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Urunler p)
        {
            var urun = db.Urunler.Find(p.UrunID);
            urun.UrunAd = p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.Fiyat = p.Fiyat;
            var ktg = db.Kategoriler.Where(m => m.KategoriID == p.UrunKategori).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}