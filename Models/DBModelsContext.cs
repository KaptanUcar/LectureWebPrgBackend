using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.EntityFramework;
using System.Data.Entity;

namespace LectureWebPrgBackend.Models {

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBModelsContext : DbContext {
        
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }


        public DBModelsContext() : base("DBConnMySQL") {

        }

        public List<ProductCategory> GetProductCategoryList() {
            return this.ProductCategories.ToList();
        }

        public List<Product> GetProductList() {
            return this.Products.ToList();
        }

    }

}