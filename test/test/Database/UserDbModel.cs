using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace test.Database
{
    public partial class UserDbModel :IdentityUser
    {
        public UserDbModel()
        {
            QueuesAsTeacher = new HashSet<QueueDbModel>();
            QueuesAsAuthor = new HashSet<QueueDbModel>();
            UsersQueues = new HashSet<UserQueueDbModel>();
        }
        public virtual ICollection<QueueDbModel> QueuesAsTeacher { get; set; }
        public virtual ICollection<QueueDbModel> QueuesAsAuthor { get; set; }

        public virtual ICollection<UserQueueDbModel> UsersQueues { get; set; }
    }
}
