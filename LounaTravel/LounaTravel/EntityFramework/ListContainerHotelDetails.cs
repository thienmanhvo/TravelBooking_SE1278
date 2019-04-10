using LounaTravel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.EntityFramework
{
    public class ListContainerHotelDetails
    {
        public List<HotelDetailsViewModel> HotelDetails { get; set; }
        public List<tbl_ImageHotel> Image { get; set; }
        public List<tbl_City> ComboBoxCity { get; set; }
        public List<tbl_Hotel> HotelHot { get; set; }
        public List<tbl_Convenient> Convenient { get; set; }
    }
}