using Models;

namespace Data.Contracts
{
    public interface IQuoteQueryRepository
    {
        Task<List<QuoteModel>> Get();
        Task<List<QuoteModel>> Get(string category);
    }
}