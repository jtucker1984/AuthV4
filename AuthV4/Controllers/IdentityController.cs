using AuthV4.Models.Dto;
using AuthV4.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AuthV4.Controllers
{
    [Route("api/identityController")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public IdentityController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) 
        {
            var idUser = new IdentityUser 
            {
              UserName = registerRequest.UserName,
              Email = registerRequest.UserName
            };
          var idResult =  await userManager.CreateAsync(idUser, registerRequest.Password);

            if (idResult.Succeeded) 
            {
                // add role to this user
                if(registerRequest.Roles != null) 
                {
                      idResult = await userManager.AddToRolesAsync(idUser, registerRequest.Roles);

                    if (idResult.Succeeded) 
                    {
                        return Ok("User registerd");
                    
                    }
                
                }
            }
               return BadRequest("Something went wrong");
        }
        [HttpPost]
        [Route("login")]

        public async Task <IActionResult> LogIn([FromBody] LogInRequest logInRequest) 
        {

            var user = await userManager.FindByEmailAsync(logInRequest.UserName);

            if (user != null) 
            { 
                var result = await userManager.CheckPasswordAsync(user, logInRequest.Password);
                if (result) 
                {
                  var roles = await userManager.GetRolesAsync(user);
                    if(roles != null) 
                    {
                    
                        var token = tokenRepository.CreateJwTToken(user, roles.ToList());

                        var resposne = new LogInResponse
                        {
                            JwtToken = token
                        };
                        return Ok(resposne);
                    }
                }
            }
            return BadRequest("Incorrect Email or Password");
        }
    }
}
