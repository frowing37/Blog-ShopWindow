using System;
using Blog_Data.Abstract;
using Blog_Data.Concrete;

namespace Blog_Data.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T obj)
        {
            using var c = new Context();
            c.Set<T>().Remove(obj);
            c.SaveChanges();
        }

        public T GetByID(int ID)
        {
            using var c = new Context();
            return c.Set<T>().Find(ID);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        /*public List<T> GetFilterList()
        {
            using var c = new Context();
            return c.Set<T>().Where(m => m.)
        }*/

        public void Insert(T obj)
        {
            using var c = new Context();
            c.Set<T>().Add(obj);
            c.SaveChanges();
        }

        public void Update(T obj)
        {
            using var c = new Context();
            c.Set<T>().Update(obj);
            c.SaveChanges();
        }
    }
}

