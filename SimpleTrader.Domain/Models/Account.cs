using System.Collections.Generic;

namespace SimpleTrader.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }
    }
}
