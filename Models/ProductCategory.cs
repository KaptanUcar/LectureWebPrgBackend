using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {
    public class ProductCategory {

        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

    }
}