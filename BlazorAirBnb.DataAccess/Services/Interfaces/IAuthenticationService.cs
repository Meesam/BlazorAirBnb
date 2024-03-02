using BlazorAirBnb.Models;
using BlazorAirBnb.Models.DTO;
using BlazorAirBnb.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.DataAccess.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> Login(LoginVM loginVM);

        Task<bool> RegisterUser(RegisterVM registerVM);
    }
}
