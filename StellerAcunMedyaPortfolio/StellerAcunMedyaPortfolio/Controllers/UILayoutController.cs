using StellerAcunMedyaPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerAcunMedyaPortfolio.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        // GET: UILayout
        StellarDbEntities2 db = new StellarDbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        
    }
}