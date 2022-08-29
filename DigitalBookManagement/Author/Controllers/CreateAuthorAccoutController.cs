using Author.Models;
using Author.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Author.Controllers
{
    [Route("api/CreateAuthorAccount")]
    [ApiController]
    public class CreateAuthorAccountController : ControllerBase
    {
        private readonly ICreateAuthorAccout _createAuthorAccout;
        public CreateAuthorAccountController(ICreateAuthorAccout createAuthorAccout)
        {
            _createAuthorAccout = createAuthorAccout;
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] User userDetails)
        {
            string result = _createAuthorAccout.CreateAuthor(userDetails);
            return Ok(result.ToList());
        }
    }
}
