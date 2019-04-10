using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.ViewModel
{

    public class HotelDetailsViewModel
    {
        public string nameHotel { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public int ? roomNumber { get; set; }
        public double? price { get; set; }
        public int? rating { get; set; }
        public DateTime? checkIn { get; set; }
        public DateTime? checkOut { get; set; }
        public string cityName { get; set; }
        public bool ? isParking { get; set; }
        public bool ? isCredit { get; set; }
    }

}