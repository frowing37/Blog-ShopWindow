using System;
using Blog_Business.Abstract;
using Blog_Data.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Business.Concrete
{
    public class CategoryProductManager : ICategoryProductService
    {
        private ICategoryProductDal _categoryProductDal;

        public CategoryProductManager(ICategoryProductDal categoryProductDal)
        {
            _categoryProductDal = categoryProductDal;
        }

        public void SDelete(CategoryProduct s)
        {
            _categoryProductDal.Delete(s);
        }

        public CategoryProduct SGetByID(int ID)
        {
            return _categoryProductDal.GetByID(ID);
        }

        public List<CategoryProduct> SGetList()
        {
            return _categoryProductDal.GetList();
        }

        public void SInsert(CategoryProduct s)
        {
            _categoryProductDal.Insert(s);
        }

        public void SUpdate(CategoryProduct s)
        {
            _categoryProductDal.Update(s);
        }
    }
}

