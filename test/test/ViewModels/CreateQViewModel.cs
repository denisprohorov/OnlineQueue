using System.ComponentModel.DataAnnotations;

namespace test.ViewModels
{
    public class CreateQViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Priority")]
        ///////////////////////////////////////////////////////////////
        public string Priority { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        /////////////////////////////////////////////////////////
        [Required]
        [Display(Name = "Teacher")]
        public string Teacher { get; set; }
    }
}
