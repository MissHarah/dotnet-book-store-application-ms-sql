using Microsoft.EntityFrameworkCore;
using MyBookApp.Data;
using MyBookApp.Models;

namespace MyBookApp.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Languages.Select(x => new LanguageModel()
            {

                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();
        }


    }
}
