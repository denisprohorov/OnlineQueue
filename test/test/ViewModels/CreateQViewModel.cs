using System.ComponentModel.DataAnnotations;
using test.Database;

namespace test.ViewModels
{
    public class CreateQViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Priority")]
        public string Priority { get; set; }
        [Required]
        [Display(Name = "About")]
        public string About { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        ////////////////////////////////
        public string Teacher { get; set; }
    }
}
