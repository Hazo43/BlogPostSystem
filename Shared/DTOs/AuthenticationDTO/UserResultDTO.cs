using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.AuthenticationDTO
{
    public record UserResultDTO
        (
         string DisplayName ,
         string Token ,
         string Email
        )
       {
       }
}
