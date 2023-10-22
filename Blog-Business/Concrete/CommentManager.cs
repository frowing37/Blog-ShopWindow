using System;
using Blog_Data.Abstract;
using Blog_Business.Abstract;
using Blog_Entities.Concrete;

namespace Blog_Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void SDelete(Comment s)
        {
            _commentDal.Delete(s);
        }

        public Comment SGetByID(int ID)
        {
            return _commentDal.GetByID(ID);
        }

        public List<Comment> SGetList()
        {
            return _commentDal.GetList();
        }

        public void SInsert(Comment s)
        {
            _commentDal.Insert(s);
        }

        public void SUpdate(Comment s)
        {
            _commentDal.Update(s);
        }
    }
}

