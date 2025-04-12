using UserManagementAPI.Models;

public class UserService
{
	private readonly List<User> _userRecords =
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

	public IEnumerable<User> GetAllUsers() => _userRecords;

	public User? GetUserById(int id) => _userRecords.FirstOrDefault(u => u.Id == id);

	public User CreateUser(User user)
	{
		user.Id = _userRecords.Max(u => u.Id) + 1;
		_userRecords.Add(user);
		return user;
	}

	public bool UpdateUser(int id, User updatedUser)
	{
		var user = _userRecords.FirstOrDefault(u => u.Id == id);
		if (user == null) return false;

		user.FirstName = updatedUser.FirstName;
		user.LastName = updatedUser.LastName;
		user.Email = updatedUser.Email;
		user.Department = updatedUser.Department;
		return true;
	}

	public bool DeleteUser(int id)
	{
		var user = _userRecords.FirstOrDefault(u => u.Id == id);
		if (user == null) return false;

		_userRecords.Remove(user);
		return true;
	}
}