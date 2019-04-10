using LounaTravel.EntityFramework;
using LounaTravel.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LounaTravel.Models
{
    public class HotelDetailsModel
    {
        private LounaTravelDbContext context = null;
        public HotelDetailsModel()
        {
            context = new LounaTravelDbContext();
        }
        public List<HotelDetailsViewModel> listHotelDetails(int ID)
        {
            var list = from a in context.tbl_Hotel
                       join b in context.tbl_City on a.CityID equals b.CityID
                       where a.ID == ID
                       select new HotelDetailsViewModel()
                       {
                           nameHotel=a.Name,
                           address = a.Address,
                           cityName = b.CityName,
                           description = a.Description,
                           email = a.Email,
                           phoneNumber = a.PhoneNumber,
                           price = a.Price,
                           rating = a.Rating,
                           roomNumber = a.RoomNumber,
                           isCredit = a.isCredit,
                           isParking = a.isParking
                           

                       };
            return list.ToList();
        }
        public List<tbl_ImageHotel> listImage(int ID)
        {
            var param = new SqlParameter("@ID",ID);
            var list = context.Database.SqlQuery<tbl_ImageHotel>("load_img_hotel_by_HotelID @ID",param).ToList();

            return list;
        }
        public List<tbl_City> listComboBoxCity()
        {
            var list = context.Database.SqlQuery<tbl_City>("db_Get_List_ComboBox_ToPlace").ToList();
            return list;
        }
        public List<tbl_Hotel> listHotelHot(int ID)
        {
            var paramID = new SqlParameter("@ID", ID);
            var list = context.Database.SqlQuery<tbl_Hotel>("db_Get_List_Hotel_Hot_Details @ID",paramID).ToList();
            foreach (tbl_Hotel hotel in list)
            {
                var param = new SqlParameter("@ID", hotel.ID);
                hotel.tbl_ImageHotel = context.Database.SqlQuery<tbl_ImageHotel>("load_img_hotel_by_HotelID @ID", param).ToList();

            }
            return list;
        }
        public List<tbl_Convenient> getListConvenient(int Id)
        {
            var param = new SqlParameter("@ID", Id);
            var list = context.Database.SqlQuery<tbl_Convenient>("db_Get_List_Convenient @ID",param).ToList();
            return list;
        }

    }

}