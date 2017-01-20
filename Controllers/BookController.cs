using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.ViewModels;
using MyFirstApp.Business;

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
        public async Task<IActionResult> Index(ProductSearchModel producSearch)
        
        {
            var business = new BookBusinessLogic();
            var model = business.SearchBook(producSearch);
            return View(await model.ToListAsync());

         }
         public ActionResult Edit(int? id)
         {
             var business = new BookBusinessLogic();
             if (id == null)
             {
                 return NotFound();
             }
             else
             {
                var book = business.GetBookByID(id);
                return View(book);
             }
         }
    }
    
}
