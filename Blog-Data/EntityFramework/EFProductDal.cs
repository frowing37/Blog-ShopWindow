using System;
using Blog_Data.Repositories;
using Blog_Entities.Concrete;
using Blog_Data.Abstract;
using Blog_Data.Concrete;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog_Data.EntityFramework
{
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> INCGetList(string p)
        {
            using (var c = new Context())
            {
                return c.Set<Product>().Include(p).ToList();
            }
        }
    }
}

