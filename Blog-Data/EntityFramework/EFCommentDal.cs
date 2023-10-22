using System;
using Blog_Data.Repositories;
using Blog_Data.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Data.EntityFramework
{
	public class EFCommentDal : GenericRepository<Comment>, ICommentDal
	{
		
	}
}

