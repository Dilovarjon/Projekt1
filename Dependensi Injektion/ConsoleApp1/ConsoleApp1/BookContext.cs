using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection") { }

        public DbSet<Book> Books { get; set; }
    }
}
