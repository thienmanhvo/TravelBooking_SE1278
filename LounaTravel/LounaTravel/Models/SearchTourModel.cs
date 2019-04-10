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
    public class SearchTourModel
    {
        private LounaTravelDbContext context = null;
        public SearchTourModel()
        {
            context = new LounaTravelDbContext();
        }

        public List<tbl_Tour> tourSearchTour(int fromPlace, int toPlace, DateTime timeBegin, int seatsRemaining)
        {

            //var fromPlaces = new SqlParameter("@fromPlace", fromPlace);
            //var toPlaces = new SqlParameter("@toPlace", toPlace);
            //var timeBegins = new SqlParameter("@timeBegin", timeBegin);
            //var seatsRemainings = new SqlParameter("@seatsRemaining", seatsRemaining);

            //var list = context.Database.SqlQuery<tbl_Tour>("db_Get_List_Search_Tour @fromPlace,@toPlace,@timeBegin,@seatsRemaining", fromPlaces, toPlaces, timeBegins, seatsRemainings).ToList();

            var list = context.Database.SqlQuery<tbl_Tour>("db_Get_List_Search_Tour @p0,@p1,@p2,@p3", fromPlace, toPlace, timeBegin, seatsRemaining).ToList();
            foreach (tbl_Tour tour in list)
            {
                var param = new SqlParameter("@TourID", tour.ID);
                tour.tbl_Image = context.Database.SqlQuery<tbl_Image>("Load_Image_Tour_Search @TourID", param).ToList();
            }
            return list;
        }
    }
}