using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace LounaTravel.Models
{
    public class ToursModel
    {
        private LounaTravelDbContext context = null;
        public ToursModel()
        {
            context = new LounaTravelDbContext();
        }
        public List<tbl_Tour> listAllTours()
        {
     
            var list = context.Database.SqlQuery<tbl_Tour>("get_All_Tour_Current").ToList();



            foreach (tbl_Tour tour in list)
            {
                var param = new SqlParameter("@TourId", tour.ID);
                tour.tbl_Image = context.Database.SqlQuery<tbl_Image>("loadImgByTourId @TourId", param).ToList();

            }
            return list;
        }
    }
}