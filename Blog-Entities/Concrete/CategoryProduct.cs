using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_Entities.Concrete
{
	public class CategoryProduct
	{
        [Key]
        public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public List<Product> Products { get; set; }
	}
}

