using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();
        public ActionResult Index()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia SocialMedia)
        {

            db.TblSocialMedia.Add(SocialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {

            var values = db.TblSocialMedia.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia tblSocialMedia)
        {
            var value = db.TblSocialMedia.FirstOrDefault(x => x.SocialMediaID == tblSocialMedia.SocialMediaID);
            value.Icon = tblSocialMedia.Icon;
            value.SocialMediaName = tblSocialMedia.SocialMediaName;
            value.Url = tblSocialMedia.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}