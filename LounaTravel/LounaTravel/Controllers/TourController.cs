using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LounaTravel.EntityFramework;
using LounaTravel.Models;
using LounaTravel.Service.TourService;
using LounaTravel.Service.OfficeService;
using System.Dynamic;
using LounaTravel.Service.Region;
using LounaTravel.Models.ViewModels;
using LounaTravel.Models.UtilityModel;

namespace LounaTravel.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;

        public TourController(TourService tourService)
        {
            _tourService = tourService;
        }


        // GET: tbl_Tour/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Trang không tồn tại" });
            }
            //tbl_Tour tbl_Tour = await db.tbl_Tour.Where(a => a.ID == id).Include(a => a.tbl_Image).SingleOrDefaultAsync();

           
            var tour = _tourService.getTourByID(id);
            if (tour == null)
            {
                return RedirectToAction("Error", "Home", new { message = "Trang không tồn tại" });
            }
            else
            {
                TourDetails viewModel = new TourDetails();
                viewModel.tbl_Tour = tour;

                IOfficeService _officeService = new OfficeService();
                viewModel.tbl_OfficeSouth = _officeService.getAllOfficeInSouthVietNam();
                viewModel.tbl_OfficeCenter = _officeService.getAllOfficeInCenterVietNam();
                viewModel.tbl_OfficeNorth = _officeService.getAllOfficeInNorthVietNam();
                viewModel.tbl_MainOffice = _officeService.getAllMainOfficeInVietNam();
                viewModel.SamePriceTourList = _tourService.getNTourByPrice(tour.PriceForAdult, tour.ID, 5);
                viewModel.SameDatedepartureTourList = _tourService.getNTourByDateBegin(tour.TimeBegin, tour.ID, 5);

                viewModel.listComboBoxFromPlace = _tourService.listComboBoxToPlace();
                viewModel.listComboBoxToPlace = _tourService.listComboBoxFromPlace();

                int days = -tour.TimeEnd.Subtract(tour.TimeBegin).Days;
                viewModel.SameDurationTourList = _tourService.getNTourByDuration(days, tour.ID, 5);


                ViewBag.isActive = UtilContants.PLACE_NAV;
                return View(viewModel);
            }
        }
    }
}
