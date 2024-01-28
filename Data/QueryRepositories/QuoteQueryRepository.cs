using Data.Contracts;
using Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.QueryRepositories
{
    public class QuoteQueryRepository : IQuoteQueryRepository
    {
        private readonly QuoteContext _context;

        public QuoteQueryRepository(QuoteContext context)
        {
            _context = context;
        }

        public async Task<List<QuoteModel>> Get()
        {
            var quotes = await (from q in _context.Quotes
                                join cq in _context.QuoteCategories on q.QuoteCategoryId equals cq.QuoteCategoryId
                                select new QuoteModel()
                                {
                                    Text = q.Text,
                                    Author = q.Author,
                                    Year = q.Year,
                                    Category = cq.Category
                                }).ToListAsync();
            return quotes;
        }

        public async Task<List<QuoteModel>> Get(string category)
        {
            var quotes = await (from q in _context.Quotes
                                join cq in _context.QuoteCategories on q.QuoteCategoryId equals cq.QuoteCategoryId
                                where cq.Category == category
                                select new QuoteModel()
                                {
                                    Text = q.Text,
                                    Author = q.Author,
                                    Year = q.Year,
                                    Category = cq.Category
                                }).ToListAsync();
            return quotes;
        }
    }
}