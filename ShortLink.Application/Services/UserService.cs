

using ShortLink.Application.Interfaces;
using ShortLink.Domain.Interfaces;

namespace ShortLink.Application.Services
{
    public class UserService: IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
    }
}
