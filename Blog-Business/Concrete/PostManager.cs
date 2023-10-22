using System;
using Blog_Data.Abstract;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public List<Post> INCSGetList(string p)
        {
            return _postDal.INCGetList(p);
        }

        public void SDelete(Post s)
        {
            _postDal.Delete(s);
        }

        public Post SGetByID(int ID)
        {
            return _postDal.GetByID(ID);
        }

        public List<Post> SGetList()
        {
            return _postDal.GetList();
        }

        public void SInsert(Post s)
        {
            _postDal.Insert(s);
        }

        public void SUpdate(Post s)
        {
            _postDal.Update(s);
        }
    }
}