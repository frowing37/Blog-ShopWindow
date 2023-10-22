using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entities.Concrete
{
	public class Product
	{
        [Key]
        public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string ProductDetails { get; set; }

		public string ImageURL { get; set; }

		public decimal ProductPrice { get; set; }

		public int NumberofLike { get; set; }

        [ForeignKey("CategoryProduct")]
        public int CategoryID { get; set; }

		public CategoryProduct CategoryProduct { get; set;}

		public List<CartProduct> CartProducts { get; set; }
	}
}

