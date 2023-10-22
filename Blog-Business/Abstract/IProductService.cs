using System;
using Blog_Entities.Concrete;

namespace Blog_Business.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> INCSGetList(string p);
	}
}

