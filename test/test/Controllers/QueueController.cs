using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test.Services;
using test.Database;

namespace test.Controllers
{
    public class QueueController : Controller
    {
        private readonly QueueService _queueService;
        private readonly ApplicationContextt _db;

        public QueueDbModel qDb;
        public QueueController()
        {
            _queueService = new QueueService();
            _db = new ApplicationContextt();
            qDb = new QueueDbModel() {OuthorId = "89", TeacherId = "69", UsersId = new List<string>(), UsersPriority = new List<int>()};
            qDb.UsersId.Add("4567");
            qDb.UsersPriority.Add(69);

        }
        public IActionResult Index()
        {
            _db.Queues.AddAsync(qDb);
            _db.SaveChangesAsync();
            return View();
        }
        public IActionResult QView(int Id)
        {
            
            return View(Id);
        }
    }
}