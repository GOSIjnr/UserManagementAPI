using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

[ApiController, Route("api/[controller]")]
public class UsersController(UserService userService) : ControllerBase
{
	private readonly UserService _userService = userService;

	[HttpGet]
	public ActionResult<IEnumerable<User>> GetUsers()
	{
		try
		{
			return Ok(_userService.GetAllUsers());
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal server error: {ex.Message}");
		}
	}

	[HttpGet("{id}")]
	public ActionResult<User> GetUser(int id)
	{
		try
		{
			var user = _userService.GetUserById(id);
			if (user == null)
			{
				return NotFound($"User with ID {id} not found.");
			}

			return Ok(user);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error retrieving user: {ex.Message}");
		}
	}

	[HttpPost]
	public ActionResult<User> CreateUser([FromBody] User user)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		try
		{
			var createdUser = _userService.CreateUser(user);
			return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error creating user: {ex.Message}");
		}
	}

	[HttpPut("{id}")]
	public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		try
		{
			var success = _userService.UpdateUser(id, updatedUser);
			if (!success)
			{
				return NotFound($"User with ID {id} not found.");
			}

			return NoContent();
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error updating user: {ex.Message}");
		}
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteUser(int id)
	{
		try
		{
			var success = _userService.DeleteUser(id);

			if (!success)
			{
				return NotFound($"User with ID {id} not found.");
			}

			return NoContent();
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error deleting user: {ex.Message}");
		}
	}
}
