using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebNothing.Application.Interfaces;
using WebNothing.Application.ViewModels;

namespace WebNothing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.authService.Authenticate(userViewModel));
        }

        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            return Ok(this.authService.IsAuthenticated());
        }
    }
}
