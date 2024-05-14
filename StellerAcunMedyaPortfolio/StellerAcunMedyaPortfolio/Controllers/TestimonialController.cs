using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StellerAcunMedyaPortfolio.Models;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();

       
        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var delete = db.TblTestimonial.Find(id);
            db.TblTestimonial.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial testimonial)
        {
            db.TblTestimonial.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            return View(db.TblTestimonial.Find(id));

        }
        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial testimonial)
        {
            var value = db.TblTestimonial.FirstOrDefault(x => x.TestimonialID == testimonial.TestimonialID);
            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Description = testimonial.Description;
            value.ImageUrl = testimonial.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}