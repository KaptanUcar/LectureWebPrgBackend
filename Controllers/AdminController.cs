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
            if(ModelState.IsValid) {
                Product pro = new Product {
                    Id = model.CreateProductModel.Id,
                    CategoryId = model.CreateProductModel.CategoryId,
                    Name = model.CreateProductModel.Name,
                    Price = model.CreateProductModel.Price,
                    ImageURL = model.CreateProductModel.ImageURL,
                    Description = model.CreateProductModel.Description
                };

                this._db.Products.Add(pro);
                this._db.SaveChanges();

                ViewBag.ActionResult = "Product " + pro.Id + " has been created.";
            }
            return View(new AdminProductsModel {
                ProductList = this._db.GetProductList(),
                CreateProductModel = model.CreateProductModel
            });
        }

        [AdminAccessNeeded]
        [HttpPost]
        public ActionResult DeleteProduct(string productID) {
            string resultMessage = null;

            if(productID.Length > 0) {
                Product found = this._db.Products.Find(productID);
                if(found != null) {
                    this._db.Products.Remove(found);
                    this._db.SaveChanges();
                    resultMessage = "Product " + productID + " has been deleted successfully.";
                }else {
                    resultMessage = "Product " + productID + " could not be found.";
                }
            }

            return RedirectToAction("Products", new { deletionResult = resultMessage });
        }

        // ---------------------

        [AdminAccessNeeded]
        public ActionResult ProductCategories() {
            return View(new AdminProductCategoriesModel {
                CategoryList = this._db.GetProductCategoryList()
            });
        }

        [AdminAccessNeeded]
        [HttpPost]
        public ActionResult ProductCategories(AdminProductCategoriesModel model) {
            if (ModelState.IsValid) {
                ProductCategory pro = new ProductCategory {
                    Id = model.CreateProductCategoryModel.Id,
                    Name = model.CreateProductCategoryModel.Name
                };

                this._db.ProductCategories.Add(pro);
                this._db.SaveChanges();

                ViewBag.ActionResult = "Product category " + pro.Id + " has been created.";
            }
            return View(new AdminProductCategoriesModel {
                CategoryList = this._db.GetProductCategoryList(),
                CreateProductCategoryModel = model.CreateProductCategoryModel
            });
        }

        [AdminAccessNeeded]
        [HttpPost]
        public ActionResult DeleteProductCategory(string categoryID) {
            string resultMessage = null;

            if (categoryID.Length > 0) {
                ProductCategory found = this._db.ProductCategories.Find(categoryID);
                if (found != null) {
                    this._db.ProductCategories.Remove(found);
                    this._db.SaveChanges();
                    resultMessage = "Product category " + categoryID + " has been deleted successfully.";
                } else {
                    resultMessage = "Product category " + categoryID + " could not be found.";
                }
            }

            return RedirectToAction("ProductCategories", new { deletionResult = resultMessage });
        }

    }
}