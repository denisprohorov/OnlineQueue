using System.Collections.Generic;

namespace test.Database
{
    public partial class QueueDbModel
    {
        public QueueDbModel()
        {
            UsersQueues = new HashSet<UserQueueDbModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string TeacherId { get; set; }
        public string AuthorId { get; set; }

        public virtual UserDbModel Teacher { get; set; }
        public virtual UserDbModel Author { get; set; }
        public virtual ICollection<UserQueueDbModel> UsersQueues { get; set; }
    }
}

