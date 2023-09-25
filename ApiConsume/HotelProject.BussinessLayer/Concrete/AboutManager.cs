using HotelProject.BussinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BussinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TDelete(AboutUs entity)
        {
            _aboutDal.Delete(entity);
        }

        public AboutUs TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<AboutUs> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TInsert(AboutUs entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TUpdate(AboutUs entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
