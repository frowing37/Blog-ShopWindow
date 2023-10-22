using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Entities.Concrete
{
	public class Cart
	{
        [Key]
        public int CartID { get; set; }

        public List<CartProduct> CartProducts { get; set; }

        [ForeignKey("AppUser")]
        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }
    }
}

