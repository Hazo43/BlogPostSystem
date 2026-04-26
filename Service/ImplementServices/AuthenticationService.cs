using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction.Interfaces;
using Shared.DTOs.AuthenticationDTO;

namespace Service.ImplementServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;

        public AuthenticationService(UserManager<User> userManager)
        {
           _userManager = userManager;
        }
        public async Task<UserResultDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
                throw null;
          
            var checkPassword = await _userManager.CheckPasswordAsync(user , loginDTO.Password);
            if (!checkPassword)
                throw null;

            return new UserResultDTO( user.DisplayName , "Token"  , user.Email);

        }

        public async Task<UserResultDTO> Register(RegisterDTO registerDTO)
        {
            var user = new User()
            {
                DisplayName = registerDTO.DisplayName,
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.Phone,
            };

            var resultCreateUser = await _userManager.CreateAsync(user , registerDTO.Password);
          
            if(resultCreateUser.Succeeded == false)
            {
                var errors = resultCreateUser.Errors.Select( e => e.Description).ToList();
                throw new Exception($" Errors {errors}");
            }

            return new UserResultDTO(user.DisplayName, "Token", user.Email);
        }
    }
}
