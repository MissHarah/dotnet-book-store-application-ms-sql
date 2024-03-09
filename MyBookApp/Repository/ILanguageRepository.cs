using MyBookApp.Models;

namespace MyBookApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}