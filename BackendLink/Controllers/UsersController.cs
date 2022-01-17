using BackendLink.Data.Services;
using BackendLink.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user")]
        public IActionResult AddUsers([FromBody] UserVM user)
        {
            _userService.AddUsers(user);
            return Ok();
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _userService.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUserById(int id, [FromBody] UserVM user)
        {
            var _updatedUser = _userService.UpdateUserById(id, user);
            return Ok(_updatedUser);
        }

        [HttpDelete("delete-user-by-id/{id}")]
        public IActionResult DelectUserById(int id)
        {
            _userService.DelectUserById(id);
            return Ok();
        }
    }
}
