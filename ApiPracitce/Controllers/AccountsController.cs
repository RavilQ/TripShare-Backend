﻿using ApiPracitce.Dtos.AccountDtos;
using ApiPractice.Core.Entities;
using ApiPractice.Core.Repositories;
using ApiPractice.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiPracitce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _conf;
        private readonly IAccountRepository _accountRepository;

        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration conf, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _conf = conf;
            _accountRepository = accountRepository;
        }

        // For creating roles

        //[HttpGet("roles")]
        //public async Task<IActionResult> Create()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));

        //    return Ok();
        //}

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            //AppUser user = await _userManager.FindByNameAsync(loginDto.UserName);

            AppUser user = await _accountRepository.GetAsync(x => x.PhoneNumber == loginDto.Number);

            if (user==null)
            {
                return BadRequest();
            }

            if (!await _userManager.CheckPasswordAsync(user,loginDto.Password))
            {
                return BadRequest();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("Fullname",user.Fullname)
            };

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role,x));
            claims.AddRange(roleClaims);

            string secret = _conf.GetSection("JWT:Secret").Value;

            var symmyetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(symmyetricSecurityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                claims:claims,
                signingCredentials:creds,
                expires:DateTime.UtcNow.AddHours(8),
                issuer: _conf.GetSection("JWT:issure").Value,
                audience: _conf.GetSection("JWT:audience").Value
                );

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {token = tokenStr});
            
        }

        //[HttpPost("")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        Fullname = "Hikmet Abbasov",
        //    };

        //    await _userManager.CreateAsync(admin, "Admin123");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return Ok();
        //}

        //[HttpPost("createUser")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "0775474948",
        //        Fullname = "Tahir Tahirli",
        //    };

        //    await _userManager.CreateAsync(admin, "Tahir123");
        //    await _userManager.AddToRoleAsync(admin, "Member");

        //    return Ok();
        //}

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {

            return Ok(new { username = User.Identity.Name });
        }


    }
}
