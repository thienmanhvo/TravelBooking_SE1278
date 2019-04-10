using LounaTravel.EntityFramework;
using LounaTravel.Models.UtilityModel;
using LounaTravel.Service.UserService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LounaTravel.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
       
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        //Check login
        public ActionResult Login(string userName, string password)
        {
            if (userName.Length == 0 || password.Length == 0)
            {
                return Json(new { status = false });
            }
            else
            {
                tbl_User user = _userService.checkLogin(userName, password);
                if (user != null)
                {

                    try
                    {
                        // The NavLoginSuccess and ContentLoginSuccess  are displayed in two partial views
                        // We can't normally return two partial views from an action, but we don't want to have another server
                        // call to get the second one, so we render the two partial views into HTML strings and package them into an
                        // an anonymous object, which we then serialize into a JSON object for sending to the client
                        // the client side script will then load these two partial views into the relevant page elements
                        var NavLoginSuccess = MultiPartialView.RenderRazorViewToString(this.ControllerContext, "NavLoginSuccess", user);
                        var ContentLoginSuccess = MultiPartialView.RenderRazorViewToString(this.ControllerContext, "ContentLoginSuccess", user);
                        return Json(new { NavLoginSuccess, ContentLoginSuccess, status = true });
                    }
                    finally
                    {

                        Session.Add(UtilContants.USER_LOGIN, user);
                    }



                }
                else
                {
                    return Json(new { status = false });
                }
            }
        }
        // Logout
        public ActionResult Logout()
        {

            tbl_User user = (tbl_User)Session[UtilContants.USER_LOGIN];
            if (user != null)
            {

                try
                {
                    // The NavLoginSuccess and ContentLoginSuccess  are displayed in two partial views
                    // We can't normally return two partial views from an action, but we don't want to have another server
                    // call to get the second one, so we render the two partial views into HTML strings and package them into an
                    // an anonymous object, which we then serialize into a JSON object for sending to the client
                    // the client side script will then load these two partial views into the relevant page elements
                    var NavLogout = MultiPartialView.RenderRazorViewToString(this.ControllerContext, "NavLogout", null);
                    var ContentLogout = MultiPartialView.RenderRazorViewToString(this.ControllerContext, "ContentLogout", null);

                    var json = Json(new { NavLogout, ContentLogout, status = true });
                    return json;
                }
                finally
                {
                    Session.Clear();
                }
            }
            else
            {
                return Json(new { status = false });
            }
        }


 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(tbl_User tbl_User)
        {

            try
            {
                if (!_userService.isExistedUser(tbl_User.Username))
                {
                    // TODO: Add insert logic here
                    if (ModelState.IsValid)
                    {
                        _userService.CreateUser(tbl_User);
                        return Json(new { status = true, message = "Đăng ký thành công!" });
                    }
                    else
                    {
                        return Json(new { status = false, message = "Đăng ký thất bại!" });
                    }
                }
                else
                {
                    return Json(new { status = false, message = "Tên tài khoản đã tồn tại!" });
                }
            }
            catch
            {
                return Json(new { status = false, message = "Đăng ký thất bại!" });
            }
        }

        [HttpPost]
        public ActionResult Edit()
        {
            string username = Request.Params["usernameEdit"];
            string email = Request.Params["EmailEdit"];
            string lastName = Request.Params["lastNameEdit"];
            string firstName = Request.Params["firstNameEdit"];
            string tel = Request.Params["telEdit"];
            int result = _userService.updateUser(username, firstName, lastName, email, tel);
            if(result > 0)
            {
                Session.Add(UtilContants.USER_LOGIN, new tbl_User { Username = username, Email = email, LastName = lastName, FirstName = firstName, PhoneNumber = tel });
                return RedirectToAction("Success", "Home", new { message = "Cập nhật thành công." });
            }
            else
            {
                return RedirectToAction("Error", "Home", new { message = "Cập nhật thất bại." });
            }          
        }
    }
}
