using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_TDPC_Net6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpGet("getasync")]
        public async Task<List<string>> GetAsync()
        {
            List<string> result = new List<string>()
            {
                "stringa 1",
                "stringa 2"
            };
            return result;
        }
        [HttpGet("GetDDLValue")]
        public async Task<object> GetDDLValue(int id)
        {
            Dictionary<int, string> values = new Dictionary<int, string>();
            values.Add(0, "zero");
            values.Add(1, "uno");
            values.Add(2, "due");
            return new
            {
                Value = values[id]
            };
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public async Task<object> GetAsync(int id)
        {
            if (id == 2)
                return BadRequest();
            else
            {
                User user = new User()
                {
                    ID = Guid.NewGuid(),
                    Nome = "Tizio",
                    Cognome = "Caio"
                };
                return Ok(user);
            }
        }

        // GET api/<APIController>?nome=valore1&cognome=valore2
        [HttpGet]
        public async Task<object> GetAsync([FromQuery] string nome, [FromQuery] string cognome)
        {
            if (nome != "Tizio")
                return BadRequest();
            else
            {
                User user = new User()
                {
                    ID = Guid.NewGuid(),
                    Nome = "Tizio FromQueryString",
                    Cognome = "Caio FromQueryString"
                };
                return Ok(user);
            }
        }

        // POST api/<APIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}