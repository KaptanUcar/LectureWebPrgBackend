using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {

    public class Product {

        [Key]
        public string Id { get; set; }

        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public float Price { get; set; }

        public string ImageURL { get; set; }

        [Column(TypeName = "longtext")]
        public string Description { get; set; }

    }

}