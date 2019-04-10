using LounaTravel.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LounaTravel.Models
{
    public class SearchHotelModel
    {
        private LounaTravelDbContext context = null;
        public SearchHotelModel()
        {
            context = new LounaTravelDbContext();
        }
        public List<tbl_Hotel> listSearchHotel(int toPlace,double price)
        {
         
            var toPlaces = new SqlParameter("@CityID", toPlace);
            var prices = new SqlParameter("@Price", price);
            var list = context.Database.SqlQuery<tbl_Hotel>("db_Get_List_Search_Hotel @CityID,@Price",toPlaces,prices).ToList();

            foreach(var hotel in list)
            {
                var param = new SqlParameter("@ID", hotel.ID);
                hotel.tbl_ImageHotel = context.Database.SqlQuery<tbl_ImageHotel>("db_Get_Image_By_HotelID @ID", param).ToList();
            }
            return list;
        }
  
    }
}