using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LounaTravel.EntityFramework;
using Z.EntityFramework.Plus;

namespace LounaTravel.Service.BookingService
{
    public class BookingService : IBookingService
    {
        private LounaTravelDbContext db = new LounaTravelDbContext();

        public IEnumerable<tbl_Booking> getBookingTourByUsername(string username)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.tbl_Booking.Where(a => a.Username == username && a.isDelete == false)
                .IncludeFilter(a => a.tbl_User)
                .IncludeFilter(a => a.tbl_Passenger.Where(b => b.isDelete == false)).ToList();
             
        }
        public void SaveBooking(tbl_Booking tbl_Booking)
        {
            try
            {
                tbl_Booking.isDelete = false;
                db.tbl_Booking.Add(tbl_Booking);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}