using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {
    public class AdminProductsModel {

        public AdminCreateProductModel CreateProductModel { get; set; }

        public List<Product> ProductList { get; set; }

    }

}