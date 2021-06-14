using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LectureWebPrgBackend.Models {
    public class AdminCreateUserModel {

        [Required(ErrorMessage = "Please enter a valid id.")]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter a category id.")]
        [Display(Name = "Category ID")]
        public string CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [Display(Name = "Price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please enter a image url.")]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

    }
}