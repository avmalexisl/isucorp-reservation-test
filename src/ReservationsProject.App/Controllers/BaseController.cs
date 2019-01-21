using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ISUCorp.ReservationsProject.App.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.CurrentLanguage = Thread.CurrentThread.CurrentUICulture.Name;
        }
        public ActionResult SetLanguage(String language)
        {
            var currentLanguage = language;
            if (currentLanguage == null)
            {
                currentLanguage = "en";
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(currentLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = currentLanguage;
            Response.Cookies.Add(cookie);

            return RedirectToAction("List");
        }
    }
}