using ShortLink.Application.DTO.Account;
using ShortLink.Application.Interfaces;
using ShortLink.Domain.Interfaces;
using ShortLink.Domain.Models.Account;
using System;
using System.Threading.Tasks;

namespace ShortLink.Application.Services
{
    public class UserService : IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;
        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task<RegisterUserResult> RegisterUser(RegisterUserDTO registerUser)
        {
            if (!await _userRepository.IsMobileExist(registerUser.Mobile))
            {
                var user = new User
                {
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    Password = _passwordHelper.EncodePasswordMd5(registerUser.Password),
                    Mobile = registerUser.Mobile,
                    MobileActiveCode = new Random().Next(10000, 9999999).ToString(),
                    CreateDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                };
                await _userRepository.AddUser(user);
                await _userRepository.SaveChange();
                return RegisterUserResult.Success;
            }
            return RegisterUserResult.IsMobileExist;
        }


        public async Task<LoginUserResult> LoginUser(LoginUserDTO loginUser)
        {
            var user = await _userRepository.GetUserByMobile(loginUser.Mobile);
            if (user == null) return LoginUserResult.NotFound;
            if (!user.IsMobileActive) return LoginUserResult.NotActivate;
            if (user.Password != _passwordHelper.EncodePasswordMd5(loginUser.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;
        }

        public async Task<User> GetUserByMobile(string mobile)
        {
            return await _userRepository.GetUserByMobile(mobile);
        }

        #endregion
    }
}
