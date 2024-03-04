using BlazorAirBnb.AuthenticationService.Services;
using BlazorAirBnb.Models;
using BlazorAirBnb.Models.Authentication.Login;
using BlazorAirBnb.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorAirBnb.Models.Response;

namespace BlazorAirBnb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserManagement _userManagement;

        public AuthenticationController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
        IConfiguration configuration, IUserManagement userManagement)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _userManagement = userManagement;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser? registerUser)
        {
            if (registerUser != null)
            {
                var token = await _userManagement.CreateUserWithTokenAsync(registerUser);
                if (token.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status200OK,
                            new Models.Response.Response { Status = "Success", Message = $"User created and send email to {registerUser.Email} successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response { Status = "Erroe", Message = $"User not created" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User cannot be null" });
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (loginModel != null)
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                var password = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if (user != null && password != null)
                {
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (userRoles != null)
                    {
                        foreach (var role in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        var jwtToken = GetToken(authClaims);
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                            expiration = jwtToken.ValidTo,
                            userId = user.Id,
                            userName = user.UserName,
                            email = user.Email,
                            Roles = userRoles,
                            user.Name,
                        });
                    }

                }
                return Unauthorized();
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User Name or Password cannot be null" });
            }

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secrete"]));

            var token = new JwtSecurityToken(
                   issuer: _configuration["JWT:ValidIssuer"],
                   audience: _configuration["JWT:ValidAudience"],
                   expires: DateTime.Now.AddHours(1),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
