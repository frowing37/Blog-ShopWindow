using System;
using Blog_Data.Abstract;
using Blog_Data.Repositories;
using Blog_Entities.Concrete;

namespace Blog_Data.EntityFramework
{
	public class EFCategoryPostDal : GenericRepository<CategoryPost>,ICategoryPostDal
	{
		
	}
}

