using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Quote
    {
#pragma warning disable CS8618
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public QuoteCategory QuoteCategory { get; set; }
        [ForeignKey("QuoteCategoryId")]
        public int QuoteCategoryId { get; set; }
    }
}