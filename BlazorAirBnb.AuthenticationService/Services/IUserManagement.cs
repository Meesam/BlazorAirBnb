using BlazorAirBnb.Models;
using BlazorAirBnb.Models.Authentication.SignUp;
using BlazorAirBnb.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.AuthenticationService.Services
{
    public interface IUserManagement
    {
        Task<ApiResponse<string>> CreateUserWithTokenAsync(RegisterUser registerUser);
        Task<ApiResponse<List<string>>> AssignRoleToUserAsync(IEnumerable<string> roles, AppUser user);
    }
}
