using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LounaTravel.Models
{
    public class HotelModel
    {
        private LounaTravelDbContext context = null;
        public HotelModel()
        {
            context = new LounaTravelDbContext();
        }
        public List<tbl_Hotel> listHotel()
        {
            var list = context.Database.SqlQuery<tbl_Hotel>("db_Get_All_Hotel").ToList();
            // get image from tbl_Image by ID
            foreach(tbl_Hotel hotel in list)
            {
                var param = new SqlParameter("@ID",hotel.ID);
                hotel.tbl_ImageHotel= context.Database.SqlQuery<tbl_ImageHotel>("db_Get_Image_By_HotelID @ID",param).ToList();
            }


            return list;

        }
    }
}