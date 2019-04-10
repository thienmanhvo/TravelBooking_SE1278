using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LounaTravel.EntityFramework;
using Z.EntityFramework.Plus;

namespace LounaTravel.Service.TourService
{
    public class TourService : ITourService
    {
        private LounaTravelDbContext context = new LounaTravelDbContext();
        public tbl_Tour getTourByID(string ID)
        {
            //tbl_Tour tbl_Tour = context.Database.SqlQuery<tbl_Tour>("spGet_Tour_byID @p0", ID).FirstOrDefault();
            //tbl_Tour.tbl_Flight = context.tbl_Flight.Where(a => a.ID == tbl_Tour.FlightID && a.isDelete == false).FirstOrDefault();
            //tbl_Tour.tbl_Hotel = context.Database.SqlQuery<tbl_Hotel>("spGet_Hotel_by_Tour_ID @p0", ID).ToList();
            //tbl_Tour.tbl_TourDetail = context.tbl_TourDetail.Where(a => a.TourID == ID && a.isDelete == false).ToList();
            //tbl_Tour.tbl_TourGuide = context.tbl_TourGuide.Where(a => a.TourGuideID == tbl_Tour.TourGuideID && a.isDelete == false).FirstOrDefault();
            //tbl_Tour.tbl_Image = context.Database.SqlQuery<tbl_Image>("loadImgByTourId @p0", ID).ToList();
            //tbl_Tour.tbl_FeedBack = context.Database.SqlQuery<tbl_FeedBack>("spGet_FeedBack_By_TourID @p0", ID).ToList();
            //foreach (var item in tbl_Tour.tbl_FeedBack)
            //{

            //    item.tbl_User = context.tbl_User.Where(a => a.Username == item.Username && a.isDelete == false).FirstOrDefault();

            //    item.tbl_ReplyBy = context.Database.SqlQuery<tbl_FeedBack>("spGet_Reply_By_FeedBackID @p0", item.ID).ToList();
            //    foreach (var reply in item.tbl_ReplyBy)
            //    {
            //        reply.tbl_User = context.tbl_User.Where(a => a.Username == reply.Username && a.isDelete == false).FirstOrDefault();
            //    }
            //}
            //return tbl_Tour;

            context.Configuration.ProxyCreationEnabled = false;
            var tour = context.tbl_Tour
                    .Where(a => a.ID == ID && a.isDelete == false)
                    .IncludeFilter(c => c.tbl_Image.Where(d => d.isDelete == false))
                    .IncludeFilter(a => a.tbl_FeedBack.Where(c => c.isDelete == false))
                    .IncludeFilter(a => a.tbl_TourDetail.Where(b => b.isDelete == false))
                    .FirstOrDefault();

            if (tour != null)
            {
                tour.tbl_Travel_Type = context.tbl_Travel_Type.Where(a => a.ID == tour.TravelTypeID && a.isDelete == false).FirstOrDefault();
                tour.tbl_Hotel = context.Database.SqlQuery<tbl_Hotel>("spGet_Hotel_by_Tour_ID @p0", ID).ToList();
                tour.tbl_Flight = context.tbl_Flight.Where(a => a.ID == tour.FlightID && a.isDelete == false).FirstOrDefault();
                tour.tbl_FromPlace = context.tbl_City.Where(a => a.CityID == tour.fromPlace && a.isDelete == false).FirstOrDefault();
                tour.tbl_TourGuide = context.tbl_TourGuide.Where(a => a.TourGuideID == tour.TourGuideID && a.isDelete == false).FirstOrDefault();
                tour.tbl_FeedBack = context.Database.SqlQuery<tbl_FeedBack>("spGet_FeedBack_By_TourID @p0", ID).ToList();
                foreach (var item in tour.tbl_FeedBack)
                {

                    item.tbl_User = context.tbl_User.Where(a => a.Username == item.Username && a.isDelete == false).FirstOrDefault();

                    item.tbl_ReplyBy = context.Database.SqlQuery<tbl_FeedBack>("spGet_Reply_By_FeedBackID @p0", item.ID).ToList();
                    foreach (var reply in item.tbl_ReplyBy)
                    {
                        reply.tbl_User = context.tbl_User.Where(a => a.Username == reply.Username && a.isDelete == false).FirstOrDefault();
                    }
                }
            }


            return tour;

        }

        public IEnumerable<tbl_Tour> getTourByPrice(double Price)
        {
            return context.tbl_Tour.Where(a => a.PriceForAdult == Price && a.isDelete == false)
                 .IncludeFilter(a => a.tbl_Image.Where(b => b.isDelete == false)).ToList();
        }
        public IEnumerable<tbl_Tour> getTourByDateBegin(DateTime timeBegin)
        {
            return context.tbl_Tour.Where(a => a.isDelete == false && a.TimeBegin == timeBegin).ToList();
        }

        public IEnumerable<tbl_Tour> getNTourByPrice(double Price, string ID, int N)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return context.tbl_Tour.Where(a => a.PriceForAdult == Price && a.isDelete == false && a.ID != ID)
               .IncludeFilter(a => a.tbl_Image.Where(b => b.isDelete == false)).OrderBy(a => a.TimeBegin).Take(N);
        }

        public IEnumerable<tbl_Tour> getNTourByDateBegin(DateTime timeBegin, string ID, int N)
        {

            return context.tbl_Tour.Where(a => a.isDelete == false && a.TimeBegin == timeBegin && a.ID != ID).OrderBy(a => a.TimeBegin).Take(N);
        }

        public IEnumerable<tbl_Tour> getTourByDuration(TimeSpan duration)
        {

            return context.tbl_Tour.Where(a => a.isDelete == false && (a.TimeEnd - a.TimeBegin) == duration).ToList();
        }

        public IEnumerable<tbl_Tour> getNTourByDuration(int duration, string ID, int N)
        {
            context.Configuration.ProxyCreationEnabled = false;
            return context.tbl_Tour.Where(a => a.isDelete == false && (DbFunctions.DiffDays(a.TimeEnd, a.TimeBegin) == duration) && a.ID != ID)
                .IncludeFilter(a => a.tbl_Image.Where(b => b.isDelete == false))
                .OrderBy(a => a.TimeBegin).Take(N);

        }
        public IEnumerable<tbl_City> listComboBoxToPlace()
        {
            return context.tbl_City.Where(a => a.isDelete == false).ToList();

        }

        public IEnumerable<tbl_City> listComboBoxFromPlace()
        {

            return context.Database.SqlQuery<tbl_City>("sp_Get_City_Have_Office").ToList();
        }

        public bool updateSeat(string TourID, int seat)
        {
            try
            {
                context.Configuration.ProxyCreationEnabled = false;
                int seatsRemaining = context.tbl_Tour.Where(a => a.ID == TourID && a.isDelete == false).FirstOrDefault().SeatsRemaining;
                if (seat > seatsRemaining)
                {
                    return false;
                }
                else { return context.Database.ExecuteSqlCommand("sp_Update_Seats @p0,@p1", seat, TourID) > 0; }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}