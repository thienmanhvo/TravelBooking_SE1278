using LounaTravel.EntityFramework;
using LounaTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using LounaTravel.Models.UtilityModel;

namespace LounaTravel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //Display Active Home
            ViewBag.isActive = UtilContants.HOME_NAV;

            TourModel model = new TourModel();
            var tour = model.listTourHot();
            var hotel = model.listHotel();
            var listComboBoxToPlace = model.listComboBoxToPlace();
            var listComboBoxFromPlace = model.listComboBoxFromPlace();
            TourHotel listContainer = new TourHotel();
            listContainer.Tour = tour;
            listContainer.Hotel = hotel;
            listContainer.listComboBoxFromPlace = listComboBoxFromPlace;
            listContainer.listComboBoxToPlace = listComboBoxToPlace;
            

            return View(listContainer);
        }

        public ActionResult Hotel(int page = 1, int pageSize = 6)
        {
            //Display Active Hotel
            ViewBag.isActive = UtilContants.HOTELS_NAV;

            var hotel = new HotelModel();
            var listHotel = hotel.listHotel().ToPagedList(page,pageSize);
            //declare TourModel to get listComboBoxToPlace method
            TourModel home = new TourModel();
            var listComboBoxToPlace = home.listComboBoxToPlace();
            // call ListContainerHotel TO contain all list
            ListContainerHotel listContainer = new ListContainerHotel();
            listContainer.Hotel = listHotel;
            listContainer.listComboBoxToPlace = listComboBoxToPlace;
            return View(listContainer);

        }

        public ActionResult Contact()
        {
            ViewBag.isActive = UtilContants.CONTACT_NAV;
            return View();
        }
        public ActionResult Tour(int page = 1 , int pageSize =6)
        {

            //Display Active Tour
            ViewBag.isActive = UtilContants.PLACE_NAV;
                
                
            ToursModel model = new ToursModel();
            TourModel home = new TourModel();
            var tours = model.listAllTours().ToPagedList(page, pageSize);
            var listComboBoxToPlace = home.listComboBoxToPlace();
            var listComboBoxFromPlace = home.listComboBoxFromPlace();
            ListContainerTravel listContainer = new ListContainerTravel();
            listContainer.Tour = tours;
            listContainer.listComboBoxFromPlace = listComboBoxFromPlace;
            listContainer.listComboBoxToPlace = listComboBoxToPlace;




            return View(listContainer);
        }

        public ActionResult Search(int page=1, int pageSize =6)
        {
            //Display Active Search Place
            ViewBag.isActive = UtilContants.PLACE_NAV;

            int fromPlace = int.Parse(Request.Params["txtFromPlace"]);
            ViewBag.fromPlaces = fromPlace;
            int  toPlace = int.Parse(Request.Params["txtToPlace"]);
            ViewBag.toPlaces = toPlace;
            DateTime timeBegin = DateTime.Parse(Request.Params["timeBegin"]);
            ViewBag.timeBegins = timeBegin;
            int traveler = int.Parse(Request.Params["traveler"]);
            ViewBag.travelers = traveler;
            var search = new SearchTourModel();
            var searchResult = search.tourSearchTour(fromPlace, toPlace, timeBegin, traveler).ToPagedList(page,pageSize);
            TourModel home = new TourModel();
            // this row will show when user search empty
            ViewBag.fromPlaceError = fromPlace;
            ViewBag.toPlaceError = toPlace;
            var listComboBoxToPlace = home.listComboBoxToPlace();
            var listComboBoxFromPlace = home.listComboBoxFromPlace();
            ListContainerTravel listContainer = new ListContainerTravel();
            listContainer.Tour = searchResult;
            listContainer.listComboBoxFromPlace = listComboBoxFromPlace;
            listContainer.listComboBoxToPlace = listComboBoxToPlace;

            return View(listContainer);
        }
      
        public ActionResult SearchHotel(int page = 1, int pageSize = 6)
        {
            //Display Active Hotel
            ViewBag.isActive = UtilContants.HOTELS_NAV;


            double price = double.Parse(Request.Params["txtPrice"]);
            ViewBag.Prices = price;
            int toPlace = int.Parse(Request.Params["txtToPlace"]);
            ViewBag.toPlaces = toPlace;
            // declare SearchHotelModel to get method listSearchHotel
            var searchHotel = new SearchHotelModel();
            var result = searchHotel.listSearchHotel(toPlace,price).ToPagedList(page, pageSize);
            //declare TourModel to get listComboBoxToPlace method
            TourModel home = new TourModel();
            var listComboBoxToPlace = home.listComboBoxToPlace();
            // call ListContainerHotel TO contain all list
            ListContainerHotel listContainer = new ListContainerHotel();
            listContainer.Hotel = result;
            listContainer.listComboBoxToPlace = listComboBoxToPlace;

            return View(listContainer);
        }
        
        //Redirect to error page
        public ActionResult Error(string message)
        {
            ViewBag.isActive = UtilContants.HOME_NAV;
            ViewBag.ERROR = message;
            return View();
        }

        //Redirect to success page
        public ActionResult Success(string message)
        {
            ViewBag.isActive = UtilContants.HOME_NAV;
            ViewBag.Message = message;
            return View();
        }

    }
}