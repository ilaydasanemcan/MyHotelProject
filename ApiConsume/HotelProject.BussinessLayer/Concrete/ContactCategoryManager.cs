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
    public class ContactCategoryManager : IContactCategoryService
    {
        private readonly IContactCategoryDal _contactCategoryDal;

        public ContactCategoryManager(IContactCategoryDal contactCategoryDal)
        {
            _contactCategoryDal = contactCategoryDal;
        }

        public void TDelete(ContactCategory entity)
        {
            _contactCategoryDal.Delete(entity);
        }

        public ContactCategory TGetById(int id)
        {
            return _contactCategoryDal.GetById(id);
        }

        public List<ContactCategory> TGetList()
        {
            return _contactCategoryDal.GetList();
        }

        public void TInsert(ContactCategory entity)
        {
            _contactCategoryDal.Insert(entity);
        }

        public void TUpdate(ContactCategory entity)
        {
            _contactCategoryDal.Update(entity);
        }
    }
}
