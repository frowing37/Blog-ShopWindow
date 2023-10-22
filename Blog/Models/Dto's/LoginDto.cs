using System;
namespace Blog.Models.Dtos
{
	public class LoginDto
	{
		public string Mail { get; set; }

		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}

