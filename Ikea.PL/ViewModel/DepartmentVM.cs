using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.ViewModel
{
    public class DepartmentVM
    {
        //now boy we will take a
        //model from updated and create and collect them here


        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]


        public string name { get; set; } = null!;

        [Required(ErrorMessage = "Code is required")]
        public string code { get; set; } = null!;

        [Display(Name = "Date of creation")]
        public DateOnly creationdate { get; set; }


        public string? description { get; set; }


    }
}
