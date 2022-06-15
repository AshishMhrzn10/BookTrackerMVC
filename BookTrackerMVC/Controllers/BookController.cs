using BookTrackerMVC.Data;
using BookTrackerMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackerMVC.Controllers
{
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Book;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
