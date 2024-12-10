using API1Ant.ActionClass.Account;
using API1Ant.ActionClass.HelperClass.DTO;
using API1Ant.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1Ant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iUser)
        {
            _IUser = iUser;
        }

        [HttpGet("user/addAccpunt")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(AccountCreate userData) => await Task.FromResult(_IUser.AddAccount(userData));

        [HttpGet("users")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> Get() => await Task.FromResult(_IUser.GetUsers());
       
    }
}
