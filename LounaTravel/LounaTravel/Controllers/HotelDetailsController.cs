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
    public class HotelDetailsController : Controller
    {
        // GET: HotelDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: HotelDetails/Details/5
        public ActionResult Details(int id)
        {
            //Display Active Hotel
            ViewBag.isActive = UtilContants.HOTELS_NAV;

            var hotel = new HotelDetailsModel();
            var listHotelDetails = hotel.listHotelDetails(id);
            var image = hotel.listImage(id);
            var listComboBoxCity = hotel.listComboBoxCity();
            var listHotelHot = hotel.listHotelHot(id);
            var listConvenient = hotel.getListConvenient(id);

            // delare ListContainerHotelDetails to container listImage and listHotelDetails
            ListContainerHotelDetails listContainer = new ListContainerHotelDetails();
            listContainer.HotelDetails = listHotelDetails;
            listContainer.Image = image;
            listContainer.ComboBoxCity = listComboBoxCity;
            listContainer.HotelHot = listHotelHot;
            listContainer.Convenient = listConvenient;
            return View(listContainer);
        }
    }
}
