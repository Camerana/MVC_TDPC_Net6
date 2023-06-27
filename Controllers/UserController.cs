using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.Models;

namespace MVC_TDPC_Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<User> GetAsync()
        {
            User user = new User()
            {
                ID = Guid.NewGuid(),
                Nome = "Dante",
                Cognome = "Alighieri"
            };
            return user;
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user != null)
            {
                user.Nome = user.Nome + " NEW";
                user.Cognome = user.Cognome + " NEW";
            }
            return Ok(user);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            if (user != null)
            {
                user.Nome = user.Nome + " NEW";
                user.Cognome = user.Cognome + " NEW";
            }
            return Ok(user);
        }
    }
}