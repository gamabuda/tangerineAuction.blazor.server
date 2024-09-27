using System;
using tangerineAuction.blazor.server.Data;

namespace tangerineAuction.blazor.server.Service
{
	public class UserService
	{
        private UserAccount _currentUser;
        private List<UserAccount> _users = new List<UserAccount>();

        public bool IsLoggedIn => _currentUser != null;
        public string CurrentUserEmail => _currentUser?.Email;

        public UserAccount GetCurrentUser()
        {
            return _currentUser;
        }

        public bool Register(string email, string password)
        {
            if (_users.Any(u => u.Email == email))
            {
                return false;
            }

            var newUser = new UserAccount(email, password);
            _currentUser = newUser;
            _users.Add(newUser);
            
            return true;
        }

        public bool Login(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                _currentUser = user;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}

