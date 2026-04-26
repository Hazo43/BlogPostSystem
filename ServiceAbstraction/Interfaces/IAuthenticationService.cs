using Shared.DTOs.AuthenticationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Interfaces
{
    public interface IAuthenticationService
    {
        // Login 
        Task<UserResultDTO> Login(LoginDTO loginDTO);
        
        // Register 
        Task<UserResultDTO> Register(RegisterDTO registerDTO);
    }
}
