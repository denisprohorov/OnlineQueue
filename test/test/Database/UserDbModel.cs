using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace test.Database
{
    public class UserDbModel : IdentityUser
    {
        public List<int> QueuesAsMember { get;set;}
        public List<int> QueuesAsTeacher { get;set;}
        public List<int> QueuesAsOuthor { get;set;}

        public List<int> FollowingQueues{get;set;}
        public List<string> FollowingUsers{get;set;}
        public List<string> Followers{get; set;}
    }
}
