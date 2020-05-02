using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public IActionResult Index(SearchModel Model = null)
        {
            if (Model.Type != null)
            {
                if(Model.Type == "User")
                {
                    if(Model.Search != null)
                    {
                        ViewBag.Users = _db.Users.Where(U => U.UserName.ToLower().Contains(Model.Search.ToLower())).ToList();
                    }else
                    {
                        ViewBag.Users = _db.Users.ToList();
                    }

                }else if(Model.Type == "Queue")
                {
                    if (Model.Search != null)
                    {
                        ViewBag.Queues = _db.Queues.Where(Q => Q.Name.ToLower().Contains(Model.Search.ToLower())).ToList();
                    }
                    else
                    {
                        ViewBag.Queues = _db.Queues.ToList();
                    }
                }
            }else{
                Model.Type = "Queue";
                ViewBag.Queues = _db.Queues.ToList();
            }
            return View(Model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
