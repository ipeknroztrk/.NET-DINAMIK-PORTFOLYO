using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class SkillController : Controller
    {

        StellarDbEntities2 db = new StellarDbEntities2();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }

        public ActionResult DeleteSkill(int id)
        {
            var values = db.TblSkill.Find(id);
            db.TblSkill.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill skill)
        {
           
            db.TblSkill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {

            var values = db.TblSkill.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSkill(TblSkill skill)
        {
            var values = db.TblSkill.Find(skill.Skillıd);
            values.Title = skill.Title;
            values.SkillName = skill.SkillName;
            values.Value = skill.Value;
            values.Description = skill.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}