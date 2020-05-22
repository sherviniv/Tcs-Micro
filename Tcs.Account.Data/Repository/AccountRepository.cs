using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Threading.Tasks;
using Tcs.Account.Domain.Models;
using Tcs.Account.Domain.Repository;
using Tcs.Common.Infrastructure.MongoDb;

namespace Tcs.Account.Data.Repository
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(MongoDbSettings settings) : base(settings)
        {
        }

        public async Task<UserAccount> GetAsync(Guid id) 
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<UserAccount> GetAsync(string userId)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task CreateAsync(UserAccount userAccount)
        {
            await Collection.InsertOneAsync(userAccount);
        }

        private IMongoCollection<UserAccount> Collection
               => _database.GetCollection<UserAccount>("UserAccounts");
    }
}
