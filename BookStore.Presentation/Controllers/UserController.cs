using BookStore.BusinessLogic.Dtos.Users;
using BookStore.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService )
        {
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var result = await _userService.CreateAsync(userCreateDto);
            return Ok(result); 
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var usersList = await _userService.GetAllUsersAsync(cancellationToken);
            return Ok(usersList);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetShipmentById(string id) 
        {
            var result = await _userService.GetByUserIdAsync(id); 
            return Ok(result);
        }

        [HttpGet("{name}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserById(string name)
        {
            var result = await _userService.GetByUserIdAsync(name);
            return Ok(result);
        }

        [HttpGet("{email}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetByUserIdAsync(email);
            return Ok(result);
        }

        [HttpPut("{UserCreateDto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateShipment([FromBody] UserCreateDto userCreateDto)
        {
            var result = await _userService.UpdateUserAsync(userCreateDto);
            return Ok(result);
        }

    }
}
