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

        public int GetBookingCount()
        {
            var context = new Context();
            var values = context.Bookings.Count();
            return values;
        }

        public int GetBookingGuestCount()
        {
            var context = new Context();
            var adultValue = context.Bookings.Select(x => x.AdultCount).ToList();
            var childValue = context.Bookings.Select(x => x.ChildCount).ToList();
            int adultCount = 0;
            int childCount = 0;
            foreach (var adult in adultValue)
            {
                adultCount = adultCount + Convert.ToInt32(adult);
            }
            foreach (var child in childValue)
            {
                childCount = childCount + Convert.ToInt32(child);
            }
            return adultCount + childCount;
        }

        public List<Booking> GetLast6Booking()
        {
            var context=new Context();
            var values=context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
            return values;
        }
    }
}
