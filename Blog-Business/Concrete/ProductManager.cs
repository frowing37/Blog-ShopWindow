using System;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;
using Blog_Data.Abstract;

namespace Blog_Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> INCSGetList(string p)
        {
            return _productDal.INCGetList(p);
        }

        public void SDelete(Product s)
        {
            _productDal.Delete(s);
        }

        public Product SGetByID(int ID)
        {
            return _productDal.GetByID(ID);
        }

        public List<Product> SGetList()
        {
            return _productDal.GetList();
        }

        public void SInsert(Product s)
        {
            _productDal.Insert(s);
        }

        public void SUpdate(Product s)
        {
            _productDal.Update(s);
        }
    }
}

