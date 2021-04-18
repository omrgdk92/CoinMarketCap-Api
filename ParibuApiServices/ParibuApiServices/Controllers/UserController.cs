using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParibuApiServices.ModelData;
using ParibuApiServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParibuApiServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(User model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost]
        public IActionResult Add(User model)
        {
            _userService.Add<User>(model);
            _userService.SaveChanges();
            return Ok(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.Users;
            return Ok(users);
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById()
        {
            var users = _userService.Users;
            return Ok(users);
        }
    }
}

