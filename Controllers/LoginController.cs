using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model) 
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if(user == null)
                return NotFound(new { message = "Usuário e senha inválidos"});

            var token = TokenService.GenerateToken(user);

            return new{
                userName = user.Username,
                role = user.Role,
                token = token
            };
        }
    }
}