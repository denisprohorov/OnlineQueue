using Microsoft.AspNetCore.Mvc;
using test.Database;
using System.Threading.Tasks;
using test.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace test.Controllers
{
    public class QueueController : Controller
    {
        private ApplicationContext _db;
        private UserManager<UserDbModel> _userManager;
        public QueueController(ApplicationContext db, UserManager<UserDbModel> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public string Index(int Id)
        {
            QueueDbModel Queue = _db.Queues.Find(Id);
            string content = "";
            content += "<ul>";
            content += "<li>Teacher - " + Queue.TeacherName + "</li>" +
                "<li>Outhor - " + Queue.OuthorName + "</li>";

            foreach (string U in Queue.UsersName)
            {
                content += "<li>" + U + "</li>";
            }

            content += "</ul>";
            return content;
        }
        public IActionResult QView(int Id = 10)
        {
            return View(_db.Queues.Find(Id));
        }
        [HttpGet]
        public IActionResult CreateQ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQ(CreateQViewModel model)
        {
            if (ModelState.IsValid)
            {
                QueueDbModel Queue = new QueueDbModel {
                Name = model.Name,
                Priority = model.Priority,
                About = model.About,
                Id = model.Id,
                TeacherName = model.TeacherName,
                OuthorName = User.Identity.Name,
                UsersName = new List<string>(),
                UsersPriority = new List<int>(),
            };
                await _db.Queues.AddAsync(Queue);
                _userManager.FindByNameAsync(User.Identity.Name).Result.QueuesAsOuthor.Add(Queue.Id);
                await _db.SaveChangesAsync();
                return RedirectToAction("QView", "Queue", new { Queue.Id });
            }
            return View(model);
        }
    }
}