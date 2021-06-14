using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {
    public class AdminProductCategoriesModel {

        public AdminCreateProductCategoryModel CreateProductCategoryModel { get; set; }

        public List<ProductCategory> CategoryList { get; set; }

    }

}