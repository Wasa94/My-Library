using System;

namespace My_Library.Models
{
    public class DataSeeder
    {
        public static void Seed(LibraryContext context)
        {
            DateTime dateTimeNowUtc = DateTime.UtcNow;

            context.Authors.Add(new Author()
            {
                Id = 1,
                FirstName = "Agatha",
                LastName = "Christie",
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 1,
                Title = "Death on the Nile",
                Description = "Detective Hercule Poirot investigates the murder of a young heiress aboard a cruise ship on the Nile River.",
                Genre = Genre.Crime,
                AuthorId = 1,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 2,
                Title = "Murder on the Orient Express",
                Description = "The Orient Express is stopped by heavy snowfall. A murder is discovered, and Poirot's trip home to London from the Middle East is interrupted to solve the case.",
                Genre = Genre.Crime,
                AuthorId = 1,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Authors.Add(new Author()
            {
                Id = 2,
                FirstName = "J.R.R.",
                LastName = "Tolkien",
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 3,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                Genre = Genre.Fantasy,
                AuthorId = 2,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 4,
                Title = "The Lord of the Rings: The Two Towers",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                Genre = Genre.Fantasy,
                AuthorId = 2,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 5,
                Title = "The Lord of the Rings: The Return of the King",
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                Genre = Genre.Fantasy,
                AuthorId = 2,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Authors.Add(new Author()
            {
                Id = 3,
                FirstName = "Frank",
                LastName = "Herbert",
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 6,
                Title = "Dune",
                Description = "A Duke's son leads desert warriors against the galactic emperor and his father's evil nemesis to free their desert world from the emperor's rule.",
                Genre = Genre.ScienceFiction,
                AuthorId = 3,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 7,
                Title = "Dune Messiah",
                Description = "The story picks up twelve years after the events of Dune with Paul as emperor and a conspiracy to bring him down.",
                Genre = Genre.ScienceFiction,
                AuthorId = 3,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.Books.Add(new Book()
            {
                Id = 8,
                Title = "Children of Dune",
                Description = "Children of Dune follows the twins Ghanima Atreides and Leto Atreides II and their rise to power.",
                Genre = Genre.ScienceFiction,
                AuthorId = 3,
                CreatedUtc = dateTimeNowUtc,
                ModifiedUtc = dateTimeNowUtc
            });

            context.SaveChanges();
        }
    }
}
