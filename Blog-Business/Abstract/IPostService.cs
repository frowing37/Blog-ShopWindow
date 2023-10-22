using System;
using Blog_Entities.Concrete;

namespace Blog_Business.Abstract
{
	public interface IPostService : IGenericService<Post>
	{
		List<Post> INCSGetList(string p);
	}
}

