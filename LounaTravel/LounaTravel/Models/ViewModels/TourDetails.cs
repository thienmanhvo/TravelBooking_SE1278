using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LounaTravel.Models.ViewModels
{
    public class TourDetails
    {
        public tbl_Tour tbl_Tour { get; set; }
        
        public IEnumerable<tbl_Office> tbl_OfficeNorth { get; set; }
        public IEnumerable<tbl_Office> tbl_OfficeSouth { get; set; }
        public IEnumerable<tbl_Office> tbl_OfficeCenter { get; set; }
        public IEnumerable<tbl_Office> tbl_MainOffice { get; set; }
        public IEnumerable<tbl_Tour> SamePriceTourList { get; set; }
        public IEnumerable<tbl_Tour> SameDatedepartureTourList { get; set; }
        public IEnumerable<tbl_Tour> SameDurationTourList { get; set; }
        public IEnumerable<tbl_City> listComboBoxToPlace { get; set; }
        public IEnumerable<tbl_City> listComboBoxFromPlace { get; set; }
    }
}