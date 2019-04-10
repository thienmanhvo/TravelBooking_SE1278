using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace LounaTravel.EntityFramework
{
    public class ListContainerHotel
    {
        public IPagedList<tbl_Hotel> Hotel { get; set; }
        public List<tbl_City> listComboBoxToPlace { get; set; }
    }
}