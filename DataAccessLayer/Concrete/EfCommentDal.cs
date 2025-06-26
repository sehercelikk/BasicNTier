using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfCommentDal : EfGenericRepository<Comment>, ICommentDal
    {
        
        public void CommentLitsWithLocationAndMember()
        {
            NTierContext _context = new NTierContext();
            var query = (from l in _context.Locations
                        join c in _context.Comments
                        on l.LocationId equals c.LocationId
                        join m in _context.Members
                        on c.MemberId equals m.MemberId
                        select new
                        {
                            l.LocationId,
                            l.LocationName,
                            m.MemberId,
                            m.Name,
                            m.Surname,
                            c.CommentId,
                            c.CommentContent
                        }).ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item.MemberId+" "+ item.Name + " " + item.LocationName+" "+item.CommentContent);
            }
        }
    }
}
