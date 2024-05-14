﻿using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
   
    public class FeatureController : Controller
    {
        StellarDbEntities2 db = new StellarDbEntities2();

        public ActionResult Index() 
        {
            var values = db.TblFeature.ToList();
            return View(values);

        }

        [HttpGet]
        public ActionResult AddFeature()  
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeature feature)
        {
            db.TblFeature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateFeature(TblFeature feature)
        {
            var value = db.TblFeature.Find(feature.FeatureID);
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            value.Job = feature.Job;
            value.imageUrl = feature.imageUrl;
            value.CvDownload = feature.CvDownload;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
