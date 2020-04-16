using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test.Services;
using test.Database;

namespace test.Controllers
{
    public class QueueController : Controller
    {
        private readonly QueueService _queueService;
        private readonly ApplicationContext _db;

        public QueueController()
        {
            _queueService = new QueueService();
            _db = new ApplicationContextt();
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QView(int Id)
        {
            
            return View(Id);
        }
    }
}