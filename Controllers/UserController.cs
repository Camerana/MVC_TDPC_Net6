using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.DB;
using MVC_TDPC_Net6.DB.Entities;
using MVC_TDPC_Net6.Models;

namespace MVC_TDPC_Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Repository repository;
        public UserController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpPost("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] UserModel model)
        {
            User user = new User();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            this.repository.InsertUser(user);
            return Ok(200);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel model)
        {
            User user = new User();
            user.ID = System.Guid.Parse(model.ID);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            this.repository.UpdateUser(user);
            return Ok(200);
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] UserModel model)
        {
            this.repository.DeleteUser(model.ID);
            return Ok(200);
        }
    }
}