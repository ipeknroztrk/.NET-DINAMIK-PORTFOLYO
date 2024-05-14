using StellerAcunMedyaPortfolio.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StellerAcunMedyaPortfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        StellarDbEntities2 db = new StellarDbEntities2();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin admin)
        {
            var values = db.Tbl_Admin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName;
                return RedirectToAction("Index", "About");
            }
        }
    }
}