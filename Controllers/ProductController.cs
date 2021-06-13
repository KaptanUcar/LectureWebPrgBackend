using LectureWebPrgBackend.Attributes;
using LectureWebPrgBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LectureWebPrgBackend.Controllers {

    [AllowCrossSiteJson]
    public class ProductController : ApiController {

        private readonly DBModelsContext _context = new DBModelsContext();

        [HttpGet]
        public IEnumerable<object> Categories() {
            List<object> list = new List<object>();

            foreach (var category in this._context.ProductCategories.AsEnumerable()) {
                list.Add(new {
                    id = category.Id,
                    name = category.Name
                });
            }

            return list;
        }

        [HttpGet]
        public IEnumerable<object> List() {
            List<object> list = new List<object>();

            foreach(var product in this._context.Products.ToList()) {
                var detailedProduct = new {
                    id = product.Id,
                    categoryID = product.CategoryId,
                    name = product.Name,
                    price = product.Price,
                    imageURL = product.ImageURL,
                    colors = new List<object>(),
                    description = product.Description
                };

                var colors = this._context.ProductColors.Where(color => color.ProductId == product.Id).ToList();
                foreach(var color in colors) {
                    detailedProduct.colors.Add(new {
                        name = color.Name,
                        cssColor = color.CssColor,
                        available = color.Available,
                        stockAmount = color.StockAmount
                    });
                }

                list.Add(detailedProduct);
            }

            return list;
        }

    }

}
