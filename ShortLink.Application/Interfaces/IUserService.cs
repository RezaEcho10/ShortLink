using ShortLink.Application.DTO.Account;
using ShortLink.Domain.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Application.Interfaces
{
    public interface IUserService
    {
        Task<RegisterUserResult> RegisterUser(RegisterUserDTO registerUser);
        Task<LoginUserResult> LoginUser(LoginUserDTO loginUser);
        Task<User> GetUserByMobile(string mobile);
    }
}
