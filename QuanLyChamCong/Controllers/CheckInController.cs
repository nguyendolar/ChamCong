using QuanLyChamCong.Daos;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChamCong.Controllers
{
    public class CheckInController : Controller
    {
        CheckInDao checkInDao = new CheckInDao();
        // GET: CheckIn
        public ActionResult Index()
        {
            var list = checkInDao.getAll();
            return View(list);
        }
        public ActionResult Supplemental(string msg)
        {
            ViewBag.Msg = msg;
            var list = checkInDao.getSup();
            return View(list);
        }

        public ActionResult CheckInUser(int id)
        {
            var list = checkInDao.getCheckInUser(id);
            return View(list);
        }
        public ActionResult SupplementalUser(int id, string msg)
        {
            ViewBag.IdUser = id;
            ViewBag.Types = checkInDao.getType();
            ViewBag.Msg = msg;
            var list = checkInDao.getSupUser(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult AddSupp(FormCollection form)
        {
            SupplementalLeave obj = new SupplementalLeave()
            {
                idType = Int32.Parse(form["idType"]),
                checkIn = TimeSpan.Parse(form["checkIn"]),
                checkOut = TimeSpan.Parse(form["checkOut"]),
                date = DateTime.Parse(form["date"]),
                reason = form["reason"],
                status = 0,
                idUser = Int32.Parse(form["idUser"]),
                timeLate = new TimeSpan(0, 0, 00)
            };
            checkInDao.addSupp(obj);
            return RedirectToAction("SupplementalUser", new {id = Int32.Parse(form["idUser"]), msg = "1" });
        }
        public ActionResult UpdateSupp(FormCollection form)
        {
            SupplementalLeave obj = new SupplementalLeave()
            {
                idSupplementalLeave = Int32.Parse(form["idSupplementalLeave"]),
                idType = Int32.Parse(form["idType"]),
                checkIn = TimeSpan.Parse(form["checkIn"]),
                checkOut = TimeSpan.Parse(form["checkOut"]),
                date = DateTime.Parse(form["date"]),
                reason = form["reason"],
            };
            checkInDao.editSupp(obj);
            return RedirectToAction("SupplementalUser", new { id = Int32.Parse(form["idUser"]), msg = "1" });
        }
        public ActionResult Approve(SupplementalLeave supplementalLeave)
        {
            checkInDao.approve(supplementalLeave);
            return RedirectToAction("Supplemental", new { msg = "1" });
        }
    }
}