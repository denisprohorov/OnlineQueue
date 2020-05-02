using System.ComponentModel.DataAnnotations;

namespace test.ViewModels
{
    public class SearchModel
    {
        [Required]
        [Display(Name = "What Find?")]
        public string Type {get;set;}

        [Required]
        [Display(Name = "data")]
        public string Search { get; set; }
    }
}
