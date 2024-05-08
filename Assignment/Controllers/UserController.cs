using Assignment.Dto;
using Assignment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class UserController :ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        [HttpGet("GetAllUser")]
        public async Task<object> Get()
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDto>> GetUserById([FromQuery] int userId)
        {
            try
            {
                var user = await _userRepository.GetUserById(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                var createdUser = await _userRepository.CreateUser(userDto);
                return Ok(createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto userDto)
        {
            try
            {
                var updatedUser = await _userRepository.UpdateUser(userDto);
                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete([FromQuery] int userId)
        {
            try
            {
                var result = await _userRepository.DeleteUser(userId);
                if (result)
                {
                    return Ok("User deleted successfully.");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
