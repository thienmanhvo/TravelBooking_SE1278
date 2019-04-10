using LounaTravel.EntityFramework;
using LounaTravel.Service.FeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LounaTravel.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IFeedBackService _feedBackService;
        // GET: FeedBack
        public FeedBackController(FeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }
        public ActionResult Index()
        {
            return View();
        }

        //Post FeedBack
        public ActionResult Comment(tbl_FeedBack tbl_FeedBack)
        {
            try
            {

                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _feedBackService.addComment(tbl_FeedBack);
                    return Json(new { status = true, message = "Trả lời thành công" });
                }
                else
                {
                    return Json(new { status = false, message = "Trả lời thất bại!" });
                }

            }
            catch (Exception)
            {
               
                return Json(new { status = false, message = "Trả lời thất bại!" });
            }

        }
    }
}