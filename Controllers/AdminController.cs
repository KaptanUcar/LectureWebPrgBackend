using LectureWebPrgBackend.Attributes;
using LectureWebPrgBackend.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace LectureWebPrgBackend.Controllers
{
    public class AdminController : Controller
    {
        [AdminAccessNeeded]
        public ActionResult Index() {
            return RedirectToAction("Products");
        }

        [AdminAccessNeeded]
        public ActionResult Products() {
            return View();
        }

        public ActionResult Login() {
            if(String.IsNullOrEmpty(HttpContext.User.Identity.Name)) {
                FormsAuthentication.SignOut();
                return View();
            }
            return RedirectToAction("Products");
        }

        [HttpPost]
        public ActionResult Login(AdminLoginModel model) {
            if(ModelState.IsValid) {
                if(model.Username == "admin" && model.Password == "123") {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    return RedirectToAction("Products");
                }else {
                    ModelState.AddModelError("", "Invalid username or password!");
                }
            }

            return View(model);
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}