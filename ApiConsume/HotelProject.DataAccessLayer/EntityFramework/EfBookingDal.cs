using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangeApproved(int id)
        {
            var context = new Context();
            var value=context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
            value.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusChangeCancel(int id)
        {
            var context = new Context();
            var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
            value.Status = "İptal Edildi";
            context.SaveChanges();
        }

        public void BookingStatusChangeWait(int id)
        {
            var context = new Context();
            var value = context.Bookings.Where(x => x.BookingID == id).FirstOrDefault();
            value.Status = "Onay Bekliyor";
            context.SaveChanges();
        }
    }
}
