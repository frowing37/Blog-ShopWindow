using System;
using Blog_Entities.Concrete;

namespace Blog_Data.Abstract
{
	public interface IPostDal : IGenericDal<Post>
	{
		List<Post> INCGetList(string p);
	}
}

