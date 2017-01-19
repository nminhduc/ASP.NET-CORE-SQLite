using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;
public class DatabaseContext : DbContext
{
  public DbSet<Book> Book { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=MyDatabase.db");
    }
}