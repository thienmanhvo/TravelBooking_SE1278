using LounaTravel.EntityFramework;
using LounaTravel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LounaTravel.Models
{
    public class TourModel
    {
        private LounaTravelDbContext context = null;
        public TourModel()
        {
            context = new LounaTravelDbContext();
        }

        public List<tbl_Tour> listTourHot()
        {


            var list = context.Database.SqlQuery<tbl_Tour>("get_List_Tour_Hot").ToList();
            foreach (tbl_Tour tour in list)
            {
                var param = new SqlParameter("@TourId", tour.ID);
                tour.tbl_Image = context.Database.SqlQuery<tbl_Image>("loadImgByTourId @TourId", param).ToList();

            }



            return list;
        }
        public List<tbl_Hotel> listHotel()
        {
            var list = context.Database.SqlQuery<tbl_Hotel>("getListHotel").ToList();
            foreach (tbl_Hotel hotel in list)
            {
                var param = new SqlParameter("@ID", hotel.ID);
                hotel.tbl_ImageHotel = context.Database.SqlQuery<tbl_ImageHotel>("load_img_hotel_by_HotelID @ID", param).ToList();

            }
            return list;
        }
        
        public List<tbl_City> listComboBoxToPlace()
        {
            var list = context.Database.SqlQuery<tbl_City>("db_Get_List_ComboBox_ToPlace").ToList();
            return list;
        }

        public List<ListComboBoxFromPlace> listComboBoxFromPlace()
        {
            var list = from a in context.tbl_City
                       join b in context.tbl_Office on a.CityID equals b.CityID
                       select new ListComboBoxFromPlace()
                       {
                           CityID = a.CityID,
                           CityName = a.CityName

                       };
            return list.Distinct().ToList();
        }


    }
}