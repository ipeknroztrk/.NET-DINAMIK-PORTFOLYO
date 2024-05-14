using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();
        public ActionResult Index()
        {

            var values = db.TblProject.ToList();
            return View(values);
        }

        public ActionResult DeleteProject(int id)
        {
            var values = db.TblProject.Find(id);
            db.TblProject.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject project)
        {
            db.TblProject.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var update = db.TblProject.Find(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject tblProject)
        {
            var value = db.TblProject.Find(tblProject.ProjectId);
            value.ProjectTitle = tblProject.ProjectTitle;
            value.ImageUrl = tblProject.ImageUrl;
            value.GithubUrl = tblProject.GithubUrl;
            value.Description = tblProject.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}