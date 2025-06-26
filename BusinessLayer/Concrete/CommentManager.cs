using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
         _commentDal = commentDal;   
        }

        public void TCommentLitsWithLocationAndMember()
        {
            _commentDal.CommentLitsWithLocationAndMember();
        }

        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment> TGetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public void TInsert(Comment entity)
        {
           _commentDal.Add(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}
