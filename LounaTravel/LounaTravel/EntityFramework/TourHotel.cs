using LounaTravel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.EntityFramework
{
    public class TourHotel
    {
        public List<tbl_Tour> Tour { get; set; }
        public List<tbl_Hotel> Hotel { get; set; }
        public List<tbl_City> listComboBoxToPlace { get; set; }
        public List<ListComboBoxFromPlace> listComboBoxFromPlace { get; set; }
  
    }
}