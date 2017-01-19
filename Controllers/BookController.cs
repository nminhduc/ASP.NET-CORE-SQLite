using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApp.Controllers
{
    public class BookController : Controller
    {
        private readonly DatabaseContext _context;
        public BookController(DatabaseContext context)
        {
             _context = new DatabaseContext();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, Title, Author, metaData")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Book.ToListAsync());
        }
    }
}
