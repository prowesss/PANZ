﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using PANZAPI.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PANZAPI.Repositories.Members;

namespace PANZAPI.Commands.Authentication
{
    public class LoginUserHandler : IRequestHandler<LoginUser, UserToken>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMembersRepository _memberRepo;

        public LoginUserHandler(UserManager<IdentityUser> userManager, IMembersRepository memberRepo, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _memberRepo = memberRepo;
        }

        public async Task<UserToken> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var jwtToken = GetToken(authClaims);

                var member = await _memberRepo.GetMembershipDetailsByUserId(user.Id);

                return new UserToken
                {   
                    Id = user.Id,
                    UserName = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    Expiration = jwtToken.ValidTo,
                    IsAdmin = userRoles.Contains("Admin"),
                    MemberId = member?.Id,
                };
            }
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Validissuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;

        }
    }
}
