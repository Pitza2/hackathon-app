using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Helpers;
using Business.Requests;
using Business.Services.Interfaces;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public IdentityService(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<ActionResponse> Login(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return new ActionResponse<string>
            {
                Action = "Login",
                Errors = new List<string> {"User does not exist!"}
            };
        }

        var passwordGood = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordGood)
        {
            return new ActionResponse<string>
            {
                Action = "Login",
                Errors = new List<string> {"Invalid credentials"}
            };

        }

        var session = new Session
        {
            UserId = user.Id,
            Token = GenerateToken(user),
            Username = user.UserName,
        };
        return new ActionResponse<Session>
        {
            Action = "Login",
            Item = session
        };
    }

    public async Task<ActionResponse<string>> Register(RegisterRequest request)
    {
        if (!request.Password.Equals(request.ConfirmPassword))
        {
            return new ActionResponse<string>
            {
                Action = "Register",
                Errors = new List<string> {"Passwords not matching!"}
            };
        }
        
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            EmailConfirmed = true,
            PhoneNumber = request.PhoneNumber
        };
        var createResult = await _userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
        {
            var response = new ActionResponse<string>
            {
                Action = "Register"
            };

            foreach (var error in createResult.Errors) response.AddError(error.Description);
            return response;
        }

        var addToRole = await _userManager.AddToRoleAsync(user, "User");


        if (addToRole.Succeeded)
            return new ActionResponse<string>
            {
                Action = "Register",
                Item = "User created successfully"
            };
        {
            var response = new ActionResponse<string>
            {
                Action = "Register"
            };

            foreach (var error in addToRole.Errors) response.AddError(error.Description);
            return response;
        }

    }

    private string GenerateToken(User newUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value);
        Console.WriteLine(_configuration.GetSection("JWT:Issuer").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new(JwtRegisteredClaimNames.Sub, newUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration.GetSection("JWT:Issuer").Value),
                new Claim("id", newUser.Id),
                new Claim(ClaimTypes.Role, "User")
            }),
            Issuer = _configuration.GetSection("JWT:Issuer").Value,
            Expires = DateTime.UtcNow.AddDays(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}