using test.Database;

namespace test.Services
{
    public class QueueService:QueueModelService
    {
    //    //private readonly ApplicationContext _applicationContextt;
    //    public QueueService()
    //    {
    //        //_applicationContextt = new ApplicationContext();
    //    }
    //    //public QueueService(QueueDbModel Queue)
    //    //{
    //    //    TeacherId = Queue.TeacherName;
    //    //    OuthorId = Queue.OuthorId;
    //    //    UsersId = Queue.UsersId;
    //    //    UsersPriority = Queue.UsersPriority;
    //    //}
    //    public void RemoveAt(int index = 0)
    //    {
    //        UsersId.RemoveAt(index);
    //        UsersPriority.RemoveAt(index);
    //    }
    //    public void AddToQueue(string Id, int Prior)
    //    {
    //        int i = UsersPriority.Count - 1;
    //        UsersId.Add(Id);
    //        UsersPriority.Add(Prior);
    //        while (i >= 0 && Prior < UsersPriority[i])
    //        {
    //            UsersId[i + 1] = UsersId[i];
    //            UsersPriority[i + 1] = UsersPriority[i];
    //            --i;
    //        }
    //        UsersId[i + 1] = Id;
    //        UsersPriority[i + 1] = Prior;
    //    }
    //    public bool IsOuthor(string Id) => Id == OuthorId;
    //    public bool IsTeacher(string Id) => Id == TeacherId;
    }

}
