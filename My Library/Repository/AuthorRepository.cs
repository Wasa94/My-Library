using Microsoft.EntityFrameworkCore;
using My_Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My_Library.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> Add(Author author)
        {
            DateTime dateTimeNowUtc = DateTime.UtcNow;
            author.CreatedUtc = dateTimeNowUtc;
            author.ModifiedUtc = dateTimeNowUtc;
            author.Id = 0;

            var result = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Author> Delete(int authorId)
        {
            bool hasBooks = await _context.Books.AnyAsync(b => b.AuthorId == authorId);
            if (hasBooks) return null;

            Author result = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);

            if (result != null)
            {
                _context.Authors.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Author> Get(int authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> Update(Author author)
        {
            Author result = await _context.Authors.FirstOrDefaultAsync(a => a.Id == author.Id);

            if (result != null)
            {
                result.FirstName = author.FirstName;
                result.LastName = author.LastName;
                result.ModifiedUtc = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
