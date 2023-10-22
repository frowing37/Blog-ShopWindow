using System;
using Blog_Entities.Concrete;

namespace Blog_Data.Abstract
{
	public interface IProductDal : IGenericDal<Product>
	{
        List<Product> INCGetList(string p);
    }
}

