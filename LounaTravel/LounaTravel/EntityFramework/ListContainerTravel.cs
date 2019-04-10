using LounaTravel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace LounaTravel.EntityFramework
{
    public class ListContainerTravel
    {
        public IPagedList<tbl_Tour> Tour { get; set; }
        public List<tbl_City> listComboBoxToPlace { get; set; }
        public List<ListComboBoxFromPlace> listComboBoxFromPlace { get; set; }
    }
}