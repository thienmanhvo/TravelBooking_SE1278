using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.Models.ViewModels
{
    public class BookingDetails
    {
        public tbl_Tour tbl_Tour { get; set; }
        public tbl_Booking tbl_Booking { get; set; }
       public int numOfPassenger { get; set; }
        public double PriceAdult { get; set; }
        public double PriceBaby{ get; set; }
        public double PriceKid { get; set; }

        public int Adult { get; set; }
        public double Kid { get; set; }
        public double Baby { get; set; }
    }
}