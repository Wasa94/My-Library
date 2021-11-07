using Microsoft.EntityFrameworkCore;
using My_Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Library.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Add(Book book)
        {
            Author author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == book.AuthorId);
            if (author == null) return null;

            DateTime dateTimeNowUtc = DateTime.UtcNow;
            book.CreatedUtc = dateTimeNowUtc;
            book.ModifiedUtc = dateTimeNowUtc;
            book.Id = 0;

            var result = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> Delete(int bookId)
        {
            Book result = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (result != null)
            {
                _context.Books.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Book> Get(int bookId)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> Update(Book book)
        {
            Author author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == book.AuthorId);
            if (author == null) return null;

            Book result = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);

            if (result != null)
            {
                result.Title = book.Title;
                result.Description = book.Description;
                result.AuthorId = book.AuthorId;
                result.Genre = book.Genre;
                result.ModifiedUtc = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
