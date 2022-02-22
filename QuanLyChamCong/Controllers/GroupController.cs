using QuanLyChamCong.Daos;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChamCong.Controllers
{
    public class GroupController : Controller
    {
        GroupDao groupDao = new GroupDao();
        // GET: Group
        public ActionResult Index(string msg)
        {
            ViewBag.Msg = msg;
            var list = groupDao.getAll();
            return View(list);
        }
        public ActionResult Add(Group group)
        {
            groupDao.add(group);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(Group group)
        {
            groupDao.update(group);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Group group)
        {
            groupDao.delete(group.idGroup);
            return RedirectToAction("Index", new { msg = "1" });
        }

       
    }
}