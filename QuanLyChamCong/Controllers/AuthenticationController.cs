using QuanLyChamCong.Daos;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChamCong.Controllers
{
    public class AuthenticationController : Controller
    {
        UserDao userDao = new UserDao();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form) 
        {
            User user = new User()
            {
                userName = form["userName"],
                password = form["password"]
            };
            if (IsValidRecaptcha(Request["g-recaptcha-response"]))
            {
                bool checkLogin = userDao.checkLogin(user.userName, user.password);
                if (checkLogin)
                {
                    var userInformation = userDao.getUserByUserName(user.userName);
                    Session.Add("USER", userInformation);
                    if(userInformation.idRole == 1)
                    {
                        var url = "/CheckIn/CheckInUser/" + userInformation.idUser;
                        return Redirect(url);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                else
                {
                    ViewBag.mess = "Thông tin tài khoản hoặc mật khẩu không chính xác";
                    return View("Login");
                }
            }
            else
            {
                ViewBag.mess = "Mã captcha không hợp lệ";
                return View("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("USER");
            return Redirect("/");
        }

        private bool IsValidRecaptcha(string recaptcha)
        {
            if (string.IsNullOrEmpty(recaptcha))
            {
                return false;
            }
            var secretKey = "6Lfqk5AeAAAAABsccTQseXIKG8yvgZYzF32Z8d8z";//Mã bí mật
            string remoteIp = Request.ServerVariables["REMOTE_ADDR"];
            string myParameters = String.Format("secret={0}&response={1}&remoteip={2}", secretKey, recaptcha, remoteIp);
            RecaptchaResult captchaResult;
            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var json = wc.UploadString("https://www.google.com/recaptcha/api/siteverify", myParameters);
                var js = new DataContractJsonSerializer(typeof(RecaptchaResult));
                var ms = new MemoryStream(Encoding.ASCII.GetBytes(json));
                captchaResult = js.ReadObject(ms) as RecaptchaResult;
                if (captchaResult != null && captchaResult.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}