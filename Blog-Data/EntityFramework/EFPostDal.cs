using System;
using Blog_Data.Abstract;
using Blog_Entities.Concrete;
using Blog_Data.Repositories;
using Blog_Data.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Blog_Data.EntityFramework
{
    public class EFPostDal : GenericRepository<Post>, IPostDal
    {
        public List<Post> INCGetList(string p)
        {
            using (var c = new Context())
            {
                return c.Set<Post>().Include(p).ToList();
            }
        }
    }
}

