using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        public string Symbol { get; set; }
        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string message, string symbol) : base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string message, string symbol, Exception innerException) : base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}
