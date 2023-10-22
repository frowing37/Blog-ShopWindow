using System;
using Blog_Business.Abstract;
using Blog_Data.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Business.Concrete
{
    public class CategoryPostManager : ICategoryPostService
    {
        private ICategoryPostDal _categoryPostDal;

        public CategoryPostManager(ICategoryPostDal categoryPostDal)
        {
            _categoryPostDal = categoryPostDal;
        }

        public void SDelete(CategoryPost s)
        {
            _categoryPostDal.Delete(s);
        }

        public CategoryPost SGetByID(int ID)
        {
            return _categoryPostDal.GetByID(ID);
        }

        public List<CategoryPost> SGetList()
        {
            return _categoryPostDal.GetList();
        }

        public void SInsert(CategoryPost s)
        {
            _categoryPostDal.Insert(s);
        }

        public void SUpdate(CategoryPost s)
        {
            _categoryPostDal.Update(s);
        }
    }
}

