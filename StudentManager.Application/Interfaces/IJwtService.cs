using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user, List<Role> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal ValidateAccessToken(string token);
        ClaimsPrincipal ValidateRefreshToken(string token);
    }
}
