using Microsoft.AspNetCore.Mvc;
using MongoBackend.Models;
using System.Diagnostics;

namespace MongoBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit(string idUser)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();
            ViewBag.UserList = db.getUser(idUser);
            return View();
        }
        public IActionResult Index()
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            ViewBag.UserList = db.getUsers();

            return View();
        }

        public ActionResult insertUser(string name, string email, int phone, string address)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.insertUser(name, email, phone, address);
            return RedirectToAction("index", "Home");
        }

        public ActionResult deleteUser(string idUser)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.deleleUser(idUser);
            return RedirectToAction("index", "Home");
        }
        public ActionResult updateUser(string idUser, string name, string email, string phone, string address)
        {
            DatabaseHelper.Database db = new DatabaseHelper.Database();

            db.updateUser(idUser, name, email, phone, address);
            return RedirectToAction("index", "Home");
        }
    }
}