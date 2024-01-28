using Models;

namespace Data.Contracts
{
    public interface IQuoteManager
    {
        Task<List<QuoteModel>> Get();
        Task<List<QuoteModel>> Get(string category);
    }
}
