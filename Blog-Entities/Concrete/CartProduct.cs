using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entities.Concrete
{
	public class CartProduct
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Cart")]
		public int CartID { get; set; }

		public Cart Cart { get; set; }

		[ForeignKey("Product")]
		public int ProductID { get; set; }

		public Product Product { get; set; }
	}
}

