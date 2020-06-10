using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Database;

namespace test.ViewModels
{
    public class SearchModel
    {
        [Required]
        [Display(Name = "Find")]
        //////////////////////////////////////
        public string Type {get;set;}

        [Required]
        [Display(Name = "data")]
        public string Search { get; set; }
        public List<QueueDbModel> Queues;
        public List<UserDbModel> Users;

    }
}
