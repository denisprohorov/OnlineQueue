using System.ComponentModel.DataAnnotations;

namespace test.Database
{
    public class UserQueueDbModel
    {
        [Required]
        public string UserId { get; set; }
        public int Priority { get; set; }
        public int Position { get; set; }
        [Required]
        public int QueueDbModelId { get; set; }

        public virtual QueueDbModel QueueDbModel { get; set; }
        public virtual UserDbModel User { get; set; }
    }
}

