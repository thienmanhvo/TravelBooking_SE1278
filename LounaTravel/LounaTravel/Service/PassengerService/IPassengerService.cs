using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LounaTravel.Service.PassengerService
{
    public interface IPassengerService
    {
        IEnumerable<tbl_Passenger> getAllPassengerByBookingID(int id);
    }
}
