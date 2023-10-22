using System;
namespace Blog.Models.Dtos
{
	public class ProductDto
	{
		public int ID { get; set; }

		public string ProductName { get; set; }

		public string ProductDetails { get; set; }

		public string ImageUrl { get; set; }

		public decimal ProductPrice { get; set; }

		public int NumberOfLike { get; set; }

		public int CategoryID { get; set; }

		public string CategoryName { get; set; }

		public string CommentName { get; set; }

		public string CommentContent { get; set; }

		public int ProductID { get; set; }
	}
}

