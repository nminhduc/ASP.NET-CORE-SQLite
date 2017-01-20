using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.ViewModels;
using MyFirstApp.Models;
using System.Collections.Generic;

namespace MyFirstApp.Business
{
  public class BookBusinessLogic
  {
    private readonly DatabaseContext _context;
      public BookBusinessLogic()
      {
          _context = new DatabaseContext();
      }
      public IQueryable<Book> SearchBook(ProductSearchModel productSearch)
      {
        var book = _context.Book.AsQueryable();
        if (productSearch != null)
        {
          if (!string.IsNullOrEmpty(productSearch.Title))
          {
            book = book.Where(x => x.Title.Contains(productSearch.Title));
          }
                          
          if (!string.IsNullOrEmpty(productSearch.Author))
          {
            book = book.Where(x => x.Title.Contains(productSearch.Author));
          }
        }
        return book;
      }

      public Book GetBookByID(int? id)
      {
        var book = _context.Book.SingleOrDefault(x => x.Id == id);
        return book;
      }
  }
}