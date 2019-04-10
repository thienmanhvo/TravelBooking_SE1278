using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.BookingService
{
    public interface IBookingService
    {
        void SaveBooking(tbl_Booking tbl_Booking);
        IEnumerable<tbl_Booking> getBookingTourByUsername(string username);
    }
}
