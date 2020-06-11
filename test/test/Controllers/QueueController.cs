using Microsoft.AspNetCore.Mvc;
using test.Database;
using System.Threading.Tasks;
using test.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            QueueDbModel Queue = _db.Queues.Include("Author").FirstOrDefaultAsync(Q => Q.Id == Id).Result;
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
                return RedirectToAction("QView", "Queue", Queue.Id  );
            }
            return View(model);
        }
        public IActionResult AjaxShowQueueInfo(int Id)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                QueueDbModel Queue = _db.Queues.Include("UsersQueues.User").FirstOrDefaultAsync(Q => Q.Id == Id).Result;
                Queue.UsersQueues = Queue.UsersQueues.OrderBy(u => u.Position).ToList<UserQueueDbModel>();
                return PartialView(Queue);
            }
            return RedirectToAction("Index", "Home");
        }
        //public bool AjaxAddToQueue(int Id, int Priority)
        //{
        //    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        return AddToQueue(Id, Priority, User.Identity.Name);
        //    }
        //    return false;
        //}
        //public bool AjaxDeleteFromQueue(int Id, string Name)
        //{
        //    QueueDbModel Queue = _db.Queues.Find(Id);
        //    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" && Queue.UsersName.Contains(Name))
        //    {
        //        _userManager.FindByNameAsync(User.Identity.Name).Result.QueuesAsMember.Remove(Queue.Id);
        //        Queue.UsersPriority.RemoveAt(Queue.UsersName.FindIndex(U => U == Name));
        //        Queue.UsersName.Remove(Name);
        //        _db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
        //public bool AjaxChangePriority(int Id, string Name, int Priority)
        //{
        //    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        QueueDbModel Queue = _db.Queues.Find(Id);
        //        int index = Queue.UsersName.FindIndex(U => U == Name);
        //        if (Queue.UsersPriority[index] == Priority) { return false; }
        //        AjaxDeleteFromQueue(Id, Name);
        //        AddToQueue(Id, Priority, Name);
        //        _db.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}

        //private bool AddToQueue(int Id, int Priority, string Name)
        //{
        //    Compare compare;
        //    QueueDbModel Queue = _db.Queues.Find(Id);
        //    compare = InitializateCompare(Queue.Priority);

        //    if (User.Identity.IsAuthenticated && !Queue.UsersName.Contains(Name))
        //    {
        //        int i = Queue.UsersPriority.Count - 1;
        //        Queue.UsersName.Add(Name);
        //        Queue.UsersPriority.Add(Priority);
        //        while (i >= 0 && !compare(Queue.UsersPriority[i], Priority))
        //        {
        //            Queue.UsersName[i + 1] = Queue.UsersName[i];
        //            Queue.UsersPriority[i + 1] = Queue.UsersPriority[i];
        //            --i;
        //        }
        //        Queue.UsersName[i + 1] = Name;
        //        Queue.UsersPriority[i + 1] = Priority;
        //        _userManager.FindByNameAsync(Name).Result.QueuesAsMember.Add(Id);
        //        _db.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}
        //private bool IsLess(int a, int b) { return (a <= b); }
        //private bool IsGreater(int a, int b) { return (a >= b); }
        //private bool IsNone(int a, int b) { return true; }

        //private delegate bool Compare(int a, int b);
        //private Compare InitializateCompare(string type)
        //{
        //    if (type == "less") { return IsLess; }
        //    else if (type == "greater") { return IsGreater; }
        //    return IsNone;
        //}
    }
}