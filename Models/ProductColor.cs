using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {

    public class ProductColor {

        [Key, Column(Order = 0), ForeignKey("Product")]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Key, Column(Order = 1), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(7)]
        public string CssColor { get; set; }

        public bool Available { get; set; }

        [DefaultValue(0)]
        public int StockAmount { get; set; }

    }

}