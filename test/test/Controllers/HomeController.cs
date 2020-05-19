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
        private SearchModel FindQueues(SearchModel searchModel)
        {
            searchModel.Queues = _db.Queues.ToList();

            if (!String.IsNullOrEmpty(searchModel.Search))
            {
                searchModel.Queues = searchModel.Queues.Where(q => q.Name.ToLower().Contains(searchModel.Search.ToLower())).ToList();
            }

            searchModel.Type = "Queue";

            return searchModel;
        }
        private SearchModel FindUsers(SearchModel searchModel)
        {
            searchModel.Users = _db.Users.ToList();
            if (!String.IsNullOrEmpty(searchModel.Search))
            {
                searchModel.Users = searchModel.Users.Where(u => u.UserName.ToLower().Contains(searchModel.Search.ToLower())).ToList();
            }
            searchModel.Type = "User";

            return searchModel;
        }
        public async Task<IActionResult> Index(SearchModel searchModel = null)
        {
            return View((searchModel.Type == "User") ? FindUsers(searchModel) : FindQueues(searchModel));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
