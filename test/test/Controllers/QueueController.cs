using Microsoft.AspNetCore.Mvc;
using test.Database;
using System.Threading.Tasks;
using test.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using test.Models;

namespace test.Controllers
{
    public class QueueController : Controller
    {
        private OnlineQueueDbContext _db;
        private UserManager<UserDbModel> _userManager;

        public QueueController(OnlineQueueDbContext db, UserManager<UserDbModel> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult QView(int Id)
        {
            QueueDbModel Queue = _db.Queues.Include("Author").Include("Teacher").FirstOrDefaultAsync(Q => Q.Id == Id).Result;
            return View(Queue);
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreateQ()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQ(CreateQViewModel model)
        {
            if (ModelState.IsValid)
            {
                QueueDbModel Queue = new QueueDbModel ()
                {
                    Title = model.Title,
                    Priority = model.Priority,
                    About = model.About,
                    //Teacher = model.Teacher,
                    Teacher = _userManager.GetUserAsync(User).Result,///////////////////////////////////////////////////////////
                    Author = _userManager.GetUserAsync(User).Result,
                };
                await _db.Queues.AddAsync(Queue);
                await _db.SaveChangesAsync();
                return RedirectToAction("QView", "Queue", new { Queue.Id});
            }
            return View(model);
        }
        public IActionResult AjaxShowQueueInfo(int Id)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                ViewBag.UserId = _userManager.GetUserId(User);
                QueueDbModel Queue = _db.Queues.Include("Author").Include("Teacher")
                                    .Include("UsersQueues.User").FirstOrDefaultAsync(Q => Q.Id == Id).Result;
                Queue.UsersQueues = Queue.UsersQueues.OrderBy(u => u.Position).ToList<UserQueueDbModel>();
                return PartialView(Queue);
            }
            return RedirectToAction("Index", "Home");
        }
        public bool AjaxAddToQueue(int QueueId, int Priority)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return AddToQueue(QueueId, Priority);
            }
            return false;
        }
        private bool AddToQueue(int QueueId, int Priority)
        {
            QueueDbModel Queue = _db.Queues.Include("UsersQueues").SingleOrDefault(Q => Q.Id == QueueId);
            Queue.UsersQueues.Add(new UserQueueDbModel()
            {
                User = _userManager.GetUserAsync(User).Result,
                Position = Queue.UsersQueues.Count(),
                Priority = Priority
            });
            /////////////////////////////////////////////////////////
            Queue.UsersQueues = Queue.UsersQueues.OrderBy(UQ => UQ.Position).ToList();
            if(Queue.Priority == PriorityTypes.Less)
                Queue.UsersQueues = Queue.UsersQueues.OrderBy(UQ => UQ.Priority).ToList();
            else if(Queue.Priority == PriorityTypes.Greater)
                Queue.UsersQueues = Queue.UsersQueues.OrderByDescending(UQ => UQ.Priority).ToList();

            int i = 0;
            foreach (var UserQueue in Queue.UsersQueues)
            {
                UserQueue.Position = i++;
            }
            _db.SaveChanges();
            return true;
        }

        public bool AjaxDeleteFromQueue(int QueueId, string UserId)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                _db.UserQueue.Remove(new UserQueueDbModel()
                {
                    QueueDbModelId = QueueId,
                    UserId = UserId,
                });
                _db.SaveChanges();
            }
            return true;
        }
        public bool AjaxChangePriority(int QueueId, string UserId, int Priority)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                QueueDbModel Queue = _db.Queues.Include("UsersQueues").SingleOrDefault(Q => Q.Id == QueueId);
                Queue.UsersQueues.ToList().Find(UQ => UQ.UserId == UserId).Priority = Priority;
                Queue.UsersQueues = Queue.UsersQueues.OrderBy(UQ => UQ.Position).ToList();
                ////////////////////////////////////////////////
                if (Queue.Priority == PriorityTypes.Less)
                    Queue.UsersQueues = Queue.UsersQueues.OrderBy(UQ => UQ.Priority).ToList();
                else if (Queue.Priority == PriorityTypes.Greater)
                    Queue.UsersQueues = Queue.UsersQueues.OrderByDescending(UQ => UQ.Priority).ToList();
                int i = 0;
                foreach (var UserQueue in Queue.UsersQueues)
                {
                    UserQueue.Position = i++;
                }

                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}