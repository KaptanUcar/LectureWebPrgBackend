using LectureWebPrgBackend.Attributes;
using LectureWebPrgBackend.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace LectureWebPrgBackend.Controllers
{
    public class AdminController : Controller {

        private readonly DBModelsContext _db = new DBModelsContext();

        [AdminAccessNeeded]
        public ActionResult Index() {
            return RedirectToAction("Products");
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

        [AdminAccessNeeded]
        public ActionResult Products() {
            return View(new AdminProductsModel {
                ProductList = this._db.GetProductList()
            });
        }

        [AdminAccessNeeded]
        [HttpPost]
        public ActionResult Products(AdminProductsModel model) {
            System.Diagnostics.Debug.WriteLine("Products POST detected | is model valid: " + ModelState.IsValid);
            if(ModelState.IsValid) {
                Product pro = new Product {
                    Id = model.CreateUserModel.Id,
                    CategoryId = model.CreateUserModel.CategoryId,
                    Name = model.CreateUserModel.Name,
                    Price = model.CreateUserModel.Price,
                    ImageURL = model.CreateUserModel.ImageURL,
                    Description = model.CreateUserModel.Description
                };

                this._db.Products.Add(pro);
                this._db.SaveChanges();

                ViewBag.ActionResult = "Product " + pro.Id + " has been created.";
            }
            return View(model);
        }

        [AdminAccessNeeded]
        [HttpDelete]
        public ActionResult Products(string productID) {
            if(productID.Length > 0) {
                Product found = this._db.Products.Find(productID);
                if(found != null) {
                    this._db.Products.Remove(found);
                    this._db.SaveChanges();
                    ViewBag.ActionResult = "Product " + productID + " has been deleted successfully.";
                }else {
                    ViewBag.ActionResult = "Product " + productID + " could not be found.";
                }
            }
            return View();
        }

    }
}