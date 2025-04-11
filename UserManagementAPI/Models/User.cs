using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models;

public class User
{
	public int Id { get; set; }
	[Required, StringLength(20)] public string FirstName { get; set; } = string.Empty;
	[Required, StringLength(20)] public string LastName { get; set; } = string.Empty;
	[Required, EmailAddress] public string Email { get; set; } = string.Empty;
	[Required] public string Department { get; set; } = string.Empty;
}
