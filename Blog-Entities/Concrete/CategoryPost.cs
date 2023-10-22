using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_Entities.Concrete
{
	public class CategoryPost
	{
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Post> Posts { get; set; }
	}
}

