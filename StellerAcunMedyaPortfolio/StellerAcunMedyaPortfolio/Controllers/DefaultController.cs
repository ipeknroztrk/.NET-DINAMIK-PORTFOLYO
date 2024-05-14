using Microsoft.Ajax.Utilities;
using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();
        // GET: Default
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeaturePartial()
        {
            ViewBag.referans = db.TblTestimonial.Count();
            ViewBag.skill = db.TblSkill.Count();
            ViewBag.project = db.TblProject.Count();
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
           
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage message)
        {
            message.IsRead = false;
            
            db.TblMessage.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblService.Where(x=>x.ServiceStatus==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProjectPartial()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultHireMePartial()
        {
            return PartialView();
        }
        public PartialViewResult DefaultContactPartial()
        {
            var values = db.TblContact.ToList();
            return PartialView(values);
        }
        public PartialViewResult UILayoutFooterPartial()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultSocialMediaPartial()
        {
            var values = db.TblSocialMedia.ToList();
            return PartialView(values);
        }
    }
}
