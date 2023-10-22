using System;
using Blog_Business.Abstract;
using Blog_Data.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public void SDelete(Cart s)
        {
            _cartDal.Delete(s);
        }

        public Cart SGetByID(int ID)
        {
            return _cartDal.GetByID(ID);
        }

        public List<Cart> SGetList()
        {
            return _cartDal.GetList();
        }

        public void SInsert(Cart s)
        {
            _cartDal.Insert(s);
        }

        public void SUpdate(Cart s)
        {
            _cartDal.Update(s);
        }
    }
}

