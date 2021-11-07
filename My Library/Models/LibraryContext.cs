using Microsoft.EntityFrameworkCore;

namespace My_Library.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(author => author.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .Property(book => book.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
