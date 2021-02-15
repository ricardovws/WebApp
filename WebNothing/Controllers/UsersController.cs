using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;
using WebNothing.Auth.Services;

namespace WebNothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.userService.Get());
        }

        [HttpGet("test")]
        [Authorize(Roles = "fullAdmin")]
        public IActionResult Test()
        {
            return Ok(true);
        }


        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserViewModel userViewModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(this.userService.Post(userViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewModel)
        {
            return Ok(this.userService.Put(userViewModel));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            int _userId = int.Parse(TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));

            return Ok(this.userService.Delete(_userId));
        }

        //little teste

    }
}
