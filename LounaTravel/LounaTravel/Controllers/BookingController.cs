using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LounaTravel.EntityFramework;
using LounaTravel.Models.UtilityModel;
using LounaTravel.Models.ViewModels;
using LounaTravel.Service.BookingService;
using LounaTravel.Service.PassengerService;
using LounaTravel.Service.TourService;

namespace LounaTravel.Controllers
{
    public class BookingController : Controller
    {

        private readonly IBookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;

        }

        //Tạo các form passenger render về trang hiện tại
        public ActionResult RenderPassenger(int Adult, int Kid, int Baby, double PriceAdult, double PriceBaby, double PriceKid)
        {
            if (Session[UtilContants.USER_LOGIN] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                BookingDetails BookingDetails = new BookingDetails();
                BookingDetails.PriceAdult = PriceAdult;
                BookingDetails.PriceBaby = PriceBaby;
                BookingDetails.PriceKid = PriceKid;
                BookingDetails.Adult = Adult;
                BookingDetails.Kid = Kid;
                BookingDetails.Baby = Baby;
                var listPassenger = MultiPartialView.RenderRazorViewToString(this.ControllerContext, "listPassenger", BookingDetails);
                return Json(new { status = true, listPassenger });
            }
        }
        //
        public ActionResult CheckOut(tbl_Booking booking, List<tbl_Passenger> tbl_Passenger)
        {
            if (Session[UtilContants.USER_LOGIN] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                try
                {
                    foreach (var item in tbl_Passenger)
                    {
                        item.isDelete = false;
                        booking.tbl_Passenger.Add(item);
                    }
                    ITourService _tourService = new TourService();

                    if (_tourService.updateSeat(booking.TourID, tbl_Passenger.Count))
                    {
                        _bookingService.SaveBooking(booking);
                        return Json(new { status = true });
                    }
                    else
                    {
                        return Json(new { status = false });

                    }

                }
                catch (Exception ee)
                {

                    return Json(new { status = false, ee });
                }

            }

        }

        //hiển thị trang booking với tour đã chọn
        [HttpGet]
        public ActionResult Index(string ID)
        {
            if (Session[UtilContants.USER_LOGIN] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ID == null || ID.Length == 0)
                {
                    return RedirectToAction("Error", "Home", new { message = "Trang không tồn tại" });
                }
                else
                {
                    ViewBag.isActive = UtilContants.PLACE_NAV;
                    ITourService _tourService = new TourService();

                    return View(_tourService.getTourByID(ID));
                }

            }
        }
        //hien thi chi tiết nguoi tham gia
        [HttpGet]
        public ActionResult DisplayPassenger(int? ID)
        {
            if (Session[UtilContants.USER_LOGIN] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (ID == null || ID.ToString().Length == 0)
                {
                    return RedirectToAction("Error", "Home", new { message = "Trang không tồn tại" });
                }
                else
                {
                    ViewBag.isActive = UtilContants.PLACE_NAV;

                    IPassengerService _passengerService = new PassengerService();
                    return View(_passengerService.getAllPassengerByBookingID(ID.GetValueOrDefault()));
                }

            }
        }
        //hiển thị các tour đã book của username
        [HttpGet]
        public ActionResult Details(string username)
        {
            if (Session[UtilContants.USER_LOGIN] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (username == null || username.Length == 0)
                {
                    return RedirectToAction("Error", "Home", new { message = "Trang không tồn tại" });
                }
                else
                {
                    ViewBag.isActive = UtilContants.PLACE_NAV;

                    var booking = _bookingService.getBookingTourByUsername(username);

                    return View(booking);
                }

            }

        }
    }
}
