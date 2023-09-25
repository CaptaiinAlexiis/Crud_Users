using Crud.Models;
using Crud.Models.Class;
using Crud.Models.DB;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            Console.WriteLine("USERS DELETE");
            MyDatabase _db = new MyDatabase();
            User _user = _db.Get(id);
            _db.Delete(_user);


            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult Users(int id, string name, string lastname, string address, string email, string phone,string birth)
        {
            Console.WriteLine("USERS UPDATE");
            MyDatabase _db = new MyDatabase();
            User _user = _db.Get(id);
            _user.Name = name;
            _user.Email = email;
            _user.LastName = lastname;
            _user.Address = address;
            _user.Phone = phone;
            DateOnly _dateOnly = DateOnly.Parse(birth);
            _user.Birth = _dateOnly;

            _db.Update(_user);
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(string name, string lastname, string address, string email, string phone,string birth)
        {
            Console.WriteLine("USERS ADD");
            MyDatabase _db = new MyDatabase();
            User _user = new User();
            _user.Name = name;
            _user.Email = email;
            _user.LastName = lastname;
            _user.Address = address;
            _user.Phone = phone;
            DateOnly _dateOnly = DateOnly.Parse(birth);
            _user.Birth = _dateOnly;

            _db.Add(_user);
            return RedirectToAction("Users");
        }

        public IActionResult UserChange()
        {
            TempData["ID"] = HttpContext.Request.GetDisplayUrl();
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}