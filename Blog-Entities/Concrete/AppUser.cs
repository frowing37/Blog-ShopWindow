using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity;

namespace Blog_Entities.Concrete
{
	public class AppUser : IdentityUser<int>
    {
		public string Name { get; set; }

		public string SecondName { get; set; }

		public string Surname { get; set; }

		public string Mail { get; set; }

		public string PhoneNumber { get; set; }

		public string Password { get; set; }

		public string ConfirmCod { get; set; }

		public List<Cart> Carts { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}

