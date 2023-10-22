using System;
namespace Blog_Data.Abstract
{
	public interface IGenericDal<T> where T : class
	{
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetByID(int ID);
        List<T> GetList();
    }
}

