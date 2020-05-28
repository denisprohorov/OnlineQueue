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
        public string Priority { get; set; }
        [Required]
        [Display(Name = "About")]
        public string About { get; set; }
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public string TeacherName { get; set; }
    }
}
