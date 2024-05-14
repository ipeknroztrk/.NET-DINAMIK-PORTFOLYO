using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class AboutController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();
        // GET: About
        public ActionResult Index()
        {
           
           // var db = new StellarDbEntities1(); bu şekilde de nesne türetebilirdik aynı işlev 
            var aboutList = db.TblAbout.ToList();
            return View(aboutList);
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = db.TblAbout.Find(id);
            //id yi bulduk tblabout içinde 
            db.TblAbout.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
            //tekrar indekse yönlendirsin
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]//sayfada butona basıldıgında ne olsun
        public ActionResult AddAbout(TblAbout about)
        {
            db.TblAbout.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout (int id)
        {
            var about = db.TblAbout.Find(id);
            
            return View(about);

        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout about)
        {
            var value = db.TblAbout.FirstOrDefault(x => x.AboutId == about.AboutId);
            value.NameSurname = about.NameSurname;
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
            
            
           
        }
    }
}