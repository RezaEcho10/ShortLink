using ShortLink.Domain.Interfaces;
using ShortLink.Domain.Models.Account;
using ShortLink.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace ShortLink.Infra.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        #region Constructor
        private readonly ShortLinkContext _context;
        public UserRepository(ShortLinkContext context)
        {
            _context = context;
        }
        #endregion
        #region Account
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }
        #endregion
        #region Dispose & Save
        public async ValueTask DisposeAsync()
        {
            if (_context != null) await _context.DisposeAsync();
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
