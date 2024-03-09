using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MyBookApp.Data;
using MyBookApp.Models;

namespace MyBookApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(Bookmodel model)
        {
            var newbook = new Book()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                Category = model.Category,
                LanguageId = model.LanguageId,
                UpdatedOn = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookpdfUrl = model.BookpdfUrl,
            };
            // var gallery = new List<BookGallery>();
            newbook.bookGallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                newbook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newbook);
            await _context.SaveChangesAsync();
            return newbook.Id;
        }
        public async Task<List<Bookmodel>> GetAllBook()
        {
            return await _context.Books
                   .Select(book => new Bookmodel()
                   {
                       Author = book.Author,
                       Category = book.Category,
                       Description = book.Description,
                       Id = book.Id,
                       LanguageId = book.LanguageId,
                       language = book.language.Name,
                       Title = book.Title,
                       TotalPages = book.TotalPages,
                       CoverImageUrl = " book.CoverImageUrl"
                   }).ToListAsync();
        }
        public async Task<List<Bookmodel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                   .Select(book => new Bookmodel()
                   {
                       Author = book.Author,
                       Category = book.Category,
                       Description = book.Description,
                       Id = book.Id,
                       LanguageId = book.LanguageId,
                       language = book.language.Name,
                       Title = book.Title,
                       TotalPages = book.TotalPages,
                       CoverImageUrl = " book.CoverImageUrl"
                   }).Take(count).ToListAsync();
        }

        public async Task<Bookmodel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                   .Select(book => new Bookmodel()
                   {
                       Author = book.Author,
                       Category = book.Category,
                       Description = book.Description,
                       Id = book.Id,
                       LanguageId = book.LanguageId,
                       Title = book.Title,
                       TotalPages = book.TotalPages,
                       CoverImageUrl = " book.CoverImageUrl",
                       Gallery = book.bookGallery.Select(g => new GalleryModel()
                       {
                           Id = g.Id,
                           Name = g.Name,
                           URL = g.URL,
                       }).ToList(),
                       BookpdfUrl = book.BookpdfUrl
                   }).FirstOrDefaultAsync();




        }
        public List<Bookmodel> searchAllBook(string title, string authorName)
        {
            // return DataSources().Where(x => x.Title == title || x.Author.Contains(authorName)).ToList();
            return null;
        }
    }
}


