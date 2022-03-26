using HelpDeskApi.Entities;
using HelpDeskApi.Models;
using HelpDeskApi.Exceptions;
using HelpDeskApi.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HelpDeskApi.Services
{
    public interface IAcountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJWT(LoginDto dto);
    }
       


    public class AcountService: IAcountService
    {

        private readonly HelpDeskDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AcountService(HelpDeskDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public HelpDeskDbContext Context { get; }

        public string GeneralJWT => throw new NotImplementedException();

        public string GenerateJWT(LoginDto dto)
        {
            var user = _context.Users
                .Include(u=>u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);
            {
                if (user is null)
                {
                    throw new BadRequestException("Niepoprawne hasło Lub E-mail");
                
                }
               var result= _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    throw new BadRequestException("Niepoprawne hasło Lub E-mail");
                }
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                    new Claim("Data Rozpoczecia pracy", user.WorkStart.Value.ToString("yyyy-MM-dd")),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

                var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                    _authenticationSettings.JwtIssuer,
                    claims,
                    expires: expires,
                    signingCredentials: cred
                    );
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(token);



            }
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                WorkStart = dto.WorkStart,
                RoleId = dto.RoleId
            };
            var hashedPassword= _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

       

       


    }
}
