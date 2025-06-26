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
    public class LocationManager : ILocationService
    {
        ILocationDal _locationDal;
        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }
        public void TDelete(Location entity)
        {
           _locationDal.Delete(entity);
        }

        public List<Location> TGetAll()
        {
            return _locationDal.GetAll();
        }

        public Location TGetById(int id)
        {
            return _locationDal.GetById(id);
        }

        public void TInsert(Location entity)
        {
            _locationDal.Add(entity);
        }

        public void TUpdate(Location entity)
        {
            _locationDal.Update(entity);
        }
    }
}
