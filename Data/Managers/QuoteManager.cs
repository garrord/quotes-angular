using Data.Contracts;
using Models;

namespace Data.Managers
{
    public class QuoteManager : IQuoteManager
    {
        private readonly IQuoteQueryRepository _queryRepository;

        public QuoteManager(IQuoteQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<QuoteModel>> Get()
        {
            var quotes = await _queryRepository.Get();
            return quotes;
        }

        public async Task<List<QuoteModel>> Get(string category)
        {
            var quotes = await _queryRepository.Get(category);
            return quotes;
        }
    }
}