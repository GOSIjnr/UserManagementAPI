using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

[ApiController, Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private static readonly List<User> _userRecords =
	[
		new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@techhive.com", Department = "HR" },
		new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@techhive.com", Department = "IT" },
		new User { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@techhive.com", Department = "Finance" },
		new User { Id = 4, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@techhive.com", Department = "Marketing" },
		new User { Id = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@techhive.com", Department = "Sales" },
		new User { Id = 6, FirstName = "Diana", LastName = "Evans", Email = "diana.evans@techhive.com", Department = "IT" },
		new User { Id = 7, FirstName = "Ethan", LastName = "Foster", Email = "ethan.foster@techhive.com", Department = "HR" },
		new User { Id = 8, FirstName = "Fiona", LastName = "Garcia", Email = "fiona.garcia@techhive.com", Department = "Finance" },
		new User { Id = 9, FirstName = "George", LastName = "Harris", Email = "george.harris@techhive.com", Department = "Marketing" },
		new User { Id = 10, FirstName = "Hannah", LastName = "Irvine", Email = "hannah.irvine@techhive.com", Department = "Sales" },
		new User { Id = 11, FirstName = "Ian", LastName = "Jackson", Email = "ian.jackson@techhive.com", Department = "IT" },
		new User { Id = 12, FirstName = "Julia", LastName = "King", Email = "julia.king@techhive.com", Department = "HR" },
		new User { Id = 13, FirstName = "Kevin", LastName = "Lewis", Email = "kevin.lewis@techhive.com", Department = "Finance" },
		new User { Id = 14, FirstName = "Laura", LastName = "Martinez", Email = "laura.martinez@techhive.com", Department = "Marketing" },
		new User { Id = 15, FirstName = "Michael", LastName = "Nelson", Email = "michael.nelson@techhive.com", Department = "Sales" },
		new User { Id = 16, FirstName = "Nina", LastName = "Owens", Email = "nina.owens@techhive.com", Department = "IT" },
		new User { Id = 17, FirstName = "Oscar", LastName = "Perez", Email = "oscar.perez@techhive.com", Department = "HR" },
		new User { Id = 18, FirstName = "Paula", LastName = "Quinn", Email = "paula.quinn@techhive.com", Department = "Finance" },
		new User { Id = 19, FirstName = "Quentin", LastName = "Roberts", Email = "quentin.roberts@techhive.com", Department = "Marketing" },
		new User { Id = 20, FirstName = "Rachel", LastName = "Smith", Email = "rachel.smith@techhive.com", Department = "Sales" }
	];

	[HttpGet]
	public ActionResult<IEnumerable<User>> GetUsers()
	{
		try
		{
			return Ok(_userRecords);
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
			var user = _userRecords.FirstOrDefault(u => u.Id == id);

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
			user.Id = _userRecords.Max(u => u.Id) + 1;
			_userRecords.Add(user);
			return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
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
			var user = _userRecords.FirstOrDefault(u => u.Id == id);
			if (user == null)
			{
				return NotFound($"User with ID {id} not found.");
			}

			user.FirstName = updatedUser.FirstName;
			user.LastName = updatedUser.LastName;
			user.Email = updatedUser.Email;
			user.Department = updatedUser.Department;

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
			var user = _userRecords.FirstOrDefault(u => u.Id == id);
			if (user == null)
				return NotFound($"User with ID {id} not found.");

			_userRecords.Remove(user);
			return NoContent();
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error deleting user: {ex.Message}");
		}
	}
}
