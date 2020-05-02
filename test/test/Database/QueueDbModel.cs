using System.Collections.Generic;

namespace test.Database
{

    public class QueueDbModel
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string OuthorName { get; set; }
        public List<string> UsersName { get; set; }
        public List<int> UsersPriority { get; set; }
        public string Priority { get;set; }
        public string Name { get;set; }
        public string About { get;set; }

    }

}
