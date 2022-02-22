using QuanLyChamCong.Daos;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChamCong.Controllers
{
    public class UserController : Controller
    {
        UserDao userDao = new UserDao();
        ReviewDao reviewDao = new ReviewDao();
        GroupDao groupDao = new GroupDao();
        // GET: User
        public ActionResult Index(string msg)
        {
            var list = userDao.getListEmployee();
            ViewBag.Groups = groupDao.getAll();
            ViewBag.Msg = msg;
            return View(list);
        }

        public ActionResult AddReview(Review review, FormCollection formCollection)
        {
            review.idUser = Int32.Parse(formCollection["id"]);
            review.status = 1;
            reviewDao.add(review);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult AddUser(User user)
        {
            user.status = 1;
            user.idRole = 1;
            bool checkExist = userDao.checkExistUsername(user.userName);
            if (checkExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                userDao.add(user);
                return RedirectToAction("Index", new { msg = "1" });
            }
           
        }

        public ActionResult Infor(int id,string msg)
        {
            var list = userDao.getInfor(id);
            ViewBag.Msg = msg;
            return View(list);
        }

        public ActionResult UpdateUser(User user)
        {
            userDao.update(user);
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult UpdateInfor(User user)
        {
            userDao.update(user);
            return RedirectToAction("Infor", new { id = user.idUser, msg = "1" });
        }
        public ActionResult Delete(User user)
        {
            userDao.delete(user.idUser);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}