using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IStokePriceService
    {
        Task<double> GetPrice(string symbol);
    }
}
