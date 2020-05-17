using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test.Database;
using test.Models;
using test.ViewModels;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ApplicationContext _db;
        public HomeController(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchType, string searchString)
        {
            var searchModel = new SearchModel();
            if (searchType == "Queue" || searchType == null)
            {
                var Queues = from q in _db.Queues
                             select q;

                if (!String.IsNullOrEmpty(searchString))
                {
                    Queues = Queues.Where(q => q.Name.ToLower().Contains(searchString.ToLower()));
                }

                searchModel.Queues = Queues.ToList();
                searchModel.Type = "Queue";

                return View(searchModel);
            }else if (searchType == "User")
            {
                var Users = from u in _db.Users
                             select u;
                if (!String.IsNullOrEmpty(searchString))
                {
                    Users = Users.Where(u => u.UserName.ToLower().Contains(searchString.ToLower()));
                }
                searchModel.Users = Users.ToList();
                searchModel.Type = "User";
                return View(searchModel);
            }
            return RedirectToAction("Index", "Home");// View(searchModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
