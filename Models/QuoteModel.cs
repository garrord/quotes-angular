namespace Models
{
    public class QuoteModel
    {
#pragma warning disable CS8618
        public string Text { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public string Category { get; set; }
    }
}