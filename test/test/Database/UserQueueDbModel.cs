namespace test.Database
{
    public class UserQueueDbModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Priority { get; set; }
        public int Position { get; set; }
        public int? QueueDbModelId { get; set; }

        public virtual QueueDbModel QueueDbModel { get; set; }
        public virtual UserDbModel User { get; set; }
    }
}

