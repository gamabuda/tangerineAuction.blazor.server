using System;
namespace tangerineAuction.blazor.server.Data
{
	public class UserAccount
	{
		public string Id { get; }
		public string Username { get; }
		public string Email { get; set; }
		public string Password { get; set; }

		public UserAccount(string email, string password)
		{
			Id = Guid.NewGuid().ToString();
			Username = Id.Substring(Id.Length - 6);

            Email = email;
			Password = password;
		}
	}
}

