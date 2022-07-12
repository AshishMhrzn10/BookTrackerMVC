using BookTrackerMVC.Areas.Identity.Data;
using BookTrackerMVC.Data;
using BookTrackerMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackerMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;
        public BookTrackerMVCContext context;
        public readonly UserManager<AuthUser> userManager;

        public BookController(ApplicationDbContext _db, BookTrackerMVCContext context, UserManager<AuthUser> userManager )
        {
            this._db = _db;
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Book;
            var filteredList = objList.Where(item => item.userId == userManager.GetUserId(User));
            return View(filteredList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book obj)
        {
           
                _db.Book.Add(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");           
           
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Book.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(Book obj)
        {
                _db.Book.Update(obj);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Book.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Book.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Book.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
