﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiBarberia;

[Route("/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserService _userService;
    private readonly IConfiguration _config;

    public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IConfiguration config)
    {
        _authenticationService = authenticationService;
        _userService = userService;
        _config = config;
    }

    [HttpPost("/authentication")]
    public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
    {
        BaseResponse validateUserResult = _authenticationService.ValidateUser(authenticationRequestBody);
        if (validateUserResult.Message == "wrong username")
        {
            return NotFound("User not found."); // 404 Not Found si el usuario no existe
        }
        else if (validateUserResult.Message == "wrong password")
        {
            return Unauthorized("Invalid password."); // 401 Unauthorized si la contraseña es incorrecta
        }

        if (validateUserResult.Result)
        {
            var user = _userService.GetUserByName(authenticationRequestBody.UserName);
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
            var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {   
                new Claim("sub", user.UserId.ToString()),
                new Claim("username", user.UserName),
                new Claim("usertype", user.UserType.ToString())
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signature);

            string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn); // 200 OK si la autenticación es exitosa
        }

        return BadRequest(); // 400 Bad Request si algo más falla
    }
}