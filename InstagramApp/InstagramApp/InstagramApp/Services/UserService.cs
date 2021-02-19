using InstagramApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstagramApp.Services
{
    class UserService
    {
		private List<User> _users = new List<User>
		{
			new User { Id = 1, Details = "My name is Ashley Montagne", Name = "Ashley Montagne" },
			new User { Id = 2, Details = "My name is Tom", Name = "Tom Seguo" },
			new User { Id = 3, Details = "My name is RachelMartin", Name = "RachelMartin" },
			new User { Id = 4, Details = "My name is Nivan Jay", Name = "Nivan Jay" },
			new User { Id = 5, Details = "My name is SanazZ", Name = "SanazZ" },
			new User { Id = 6, Details = "My name is NextLab", Name = "NextLab" },
			new User { Id = 7, Details = "My name is Alex B", Name = "AlexB" },
			new User { Id = 8, Details = "My name is Tara Chang", Name = "Tara Chang" },
			new User { Id = 9, Details = "My name is TomK", Name = "Tom K" },
		};

		public User GetUser(int userId)
        {
			return _users.SingleOrDefault(u => u.Id == userId);
        }
    }
}
