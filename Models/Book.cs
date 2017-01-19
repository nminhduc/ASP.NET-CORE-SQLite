using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyFirstApp.Models
{
  public class Book
  {
    [Key]
    public int Id { get; set; }
    public string Title { get; set;}
    public string Author { get; set;}
    public string metaData {get; set;}
  }
  // public class BloggingContext : DbContext
  //   {
  //       public DbSet<Book> Posts { get; set; }

  //       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  //       {
  //           optionsBuilder.UseSqlite("Filename=./MyDatabase.db");
  //       }
  //   }
}