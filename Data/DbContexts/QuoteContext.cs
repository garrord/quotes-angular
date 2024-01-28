using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Data.DbContexts
{
    public class QuoteContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteCategory> QuoteCategories { get; set; }

        public QuoteContext(DbContextOptions options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Categoires
            modelBuilder.Entity<QuoteCategory>().HasData(
                new QuoteCategory()
                {
                    QuoteCategoryId = 1,
                    Category = "Movies"
                },
                new QuoteCategory()
                {
                    QuoteCategoryId = 2,
                    Category = "Inspirational"
                },
                new QuoteCategory()
                {
                    QuoteCategoryId = 3,
                    Category = "Love"
                },
                new QuoteCategory()
                {
                    QuoteCategoryId = 4,
                    Category = "Humerous"
                }
            );
            #endregion

            #region Movie Quotes
            modelBuilder.Entity<Quote>().HasData(
                new Quote()
                {
                    Id = 1,
                    Text = "Frankly, my dear, I don't give a damn.",
                    Author = "Gone with the Wind",
                    Year = 1939,
                    QuoteCategoryId = 1
                },
                new Quote()
                {
                    Id = 2,
                    Text = "You had mne at \"Hello\".",
                    Author = "Jerry Maguire",
                    Year = 1996,
                    QuoteCategoryId = 1
                },
                new Quote()
                {
                    Id = 3,
                    Text = "Here's Johnny.",
                    Author = "The Shining",
                    Year = 1980,
                    QuoteCategoryId = 1
                },
            #endregion
            #region Inspirational Quotes
                new Quote()
                {
                    Id = 4,
                    Text = "Out of the mountain of despair, a stone of hope.",
                    Author = "Martin Luther King, Jr.",
                    QuoteCategoryId = 2
                },
                new Quote()
                {
                    Id = 5,
                    Text = "When you have a dream, you've got to grab it and never let go.",
                    Author = "Carol Burnett",
                    QuoteCategoryId = 2
                },
                new Quote()
                {
                    Id = 6,
                    Text = "The bad news is time flies. The good news is you're the pilot.",
                    Author = "Michael Altshuler",
                    QuoteCategoryId = 2
                },
            #endregion
            #region Love Quotes
                new Quote()
                {
                    Id = 7,
                    Text = "You are my heart, my life, my one and only thought.",
                    Author = "Sir Arthur Conan Doyle, The White Company",
                    QuoteCategoryId = 3
                },
                new Quote()
                {
                    Id = 8,
                    Text = "There is no remedy for love but to love more.",
                    Author = "Henry David Thoreau",
                    QuoteCategoryId = 3
                },
                new Quote()
                {
                    Id = 9,
                    Text = "Of all forms of caution, caution in love is perhaps the most fatal to true happiness.",
                    Author = "Bertrand Russell, The Conquest of Happiness",
                    QuoteCategoryId = 3
                },
            #endregion
            #region Humerous Quotes
                new Quote()
                {
                    Id = 10,
                    Text = "My mother always used to say: The older you get,the better you get,unless you’re a banana.",
                    Author = "Rose (Betty White), \"The Golden Girls\"",
                    QuoteCategoryId = 4                
                },
                new Quote()
                {
                    Id = 11,
                    Text = "Halloween is the beginning of the holiday shopping season. That’s for women. The beginning of the holiday shopping season for men is Christmas Eve.",
                    Author = "David Lettermn",
                    QuoteCategoryId = 4
                },
                new Quote()
                {
                    Id = 12,
                    Text = "Clothes make the man. Naked people have little or no influence in society.",
                    Author = "Mark Twain",
                    QuoteCategoryId = 4
                }
            );
            #endregion
        }
    }
}