namespace SimpleTrader.Domain.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public Stock Stock { get; set; }
        public int Shares { get; set; }
    }
}
