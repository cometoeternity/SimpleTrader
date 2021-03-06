using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFrameworkCore.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFrameworkCore.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;


        public AccountDataService(SimpleTraderDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(contextFactory);
        }
        public async Task<Account> Create(Account entity) => await _nonQueryDataService.Create(entity);


        public async Task<bool> Delete(int id) => await _nonQueryDataService.Delete(id);
        

        public async Task<Account> Get(int id)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            Account entity = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            IEnumerable<Account> entities = await context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .ToListAsync();
            return entities;
        }

        public Task<Account> GetByEmail(string email)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
        }

        public Task<Account> GetByUsername(string username)
        {
            using SimpleTraderDbContext context = _contextFactory.CreateDbContext();
            return context.Accounts
                .Include(a => a.AccountHolder)
                .Include(a => a.AssetTransactions)
                .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
        }

        public async Task<Account> Update(int id, Account entity) => await _nonQueryDataService.Update(id, entity);
      
    }
}
