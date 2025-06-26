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
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void TDelete(Member entity)
        {
            _memberDal.Delete(entity);
        }

        public List<Member> TGetAll()
        {
            return _memberDal.GetAll();
        }

        public Member TGetById(int id)
        {
            return _memberDal.GetById(id);
        }

        public void TInsert(Member entity)
        {
            _memberDal.Add(entity);
        }

        public void TUpdate(Member entity)
        {
            _memberDal.Update(entity);
        }
    }
}
