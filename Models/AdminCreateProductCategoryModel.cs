using System.ComponentModel.DataAnnotations;

namespace LectureWebPrgBackend.Models {
    public class AdminCreateProductCategoryModel {

        [Required(ErrorMessage = "Please enter a valid id.")]
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}