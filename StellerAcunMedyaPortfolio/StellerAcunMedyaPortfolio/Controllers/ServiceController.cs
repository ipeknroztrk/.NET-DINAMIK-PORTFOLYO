using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var values = db.TblService.Find(id);
            db.TblService.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService service)
        {
            service.ServiceStatus = false;
            db.TblService.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            
            var values =db. TblService.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService service)
        {
            var values = db.TblService.Find(service.ServiceId);
            values.ServiceName = service.ServiceName;
            values.ServiceIconUrl = service.ServiceIconUrl;
            values.ServiceStatus = service.ServiceStatus;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakeActive(int id)
        {
            var values = db.TblService.Find(id);
            values.ServiceStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            var values = db.TblService.Find(id);
            values.ServiceStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}