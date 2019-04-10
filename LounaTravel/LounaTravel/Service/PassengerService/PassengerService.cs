using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LounaTravel.EntityFramework;
using Z.EntityFramework.Plus;

namespace LounaTravel.Service.PassengerService
{
    public class PassengerService : IPassengerService
    {
        private LounaTravelDbContext db = new LounaTravelDbContext();
        public IEnumerable<tbl_Passenger> getAllPassengerByBookingID(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.tbl_Passenger.Where(a => a.BookingID == id && a.isDelete == false)
                .IncludeFilter(a => a.tbl_Booking)
                .ToList();
        }
    }
}