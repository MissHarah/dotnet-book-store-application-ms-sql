using MyBookApp.Models;

namespace MyBookApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(Bookmodel model);
        Task<List<Bookmodel>> GetAllBook();
        Task<Bookmodel> GetBookById(int id);
        Task<List<Bookmodel>> GetTopBooksAsync(int count);
        List<Bookmodel> searchAllBook(string title, string authorName);
    }
}