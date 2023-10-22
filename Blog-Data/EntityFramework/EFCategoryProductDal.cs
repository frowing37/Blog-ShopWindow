using System;
using Blog_Entities.Concrete;
using Blog_Data.Abstract;
using Blog_Data.Repositories;

namespace Blog_Data.EntityFramework
{
	public class EFCategoryProductDal : GenericRepository<CategoryProduct>,ICategoryProductDal
	{
		public EFCategoryProductDal()
		{
		}
	}
}

