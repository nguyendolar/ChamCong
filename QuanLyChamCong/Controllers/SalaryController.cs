using QuanLyChamCong.Daos;
using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChamCong.Controllers
{
    public class SalaryController : Controller
    {
        SalaryDao salaryDao = new SalaryDao();
        UserDao userDao = new UserDao();
        // GET: Salary
        public ActionResult Index(string msg)
        {
            ViewBag.Users = userDao.getListEmployee();
            ViewBag.Msg = msg;
            var list = salaryDao.getAll();
            return View(list);
        }

        public ActionResult Employee(int id)
        {
            var list = salaryDao.getUser(id);
            return View(list);
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            Salary salaryObj = new Salary()
            {
                idUser = Int32.Parse(form["idUser"]),
                salary = Int32.Parse(form["salary"]),
                month = Int32.Parse(form["month"]),
                status = 0
            };
            salaryDao.add(salaryObj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(FormCollection form)
        {
            Salary salaryObj = new Salary()
            {
                idSalary = Int32.Parse(form["idSalary"]),
                idUser = Int32.Parse(form["idUser"]),
                salary = Int32.Parse(form["salary"]),
                month = Int32.Parse(form["month"])
            };
            salaryDao.update(salaryObj);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult ChangeStatus(FormCollection form)
        {
            Salary salaryObj = new Salary()
            {
                idSalary = Int32.Parse(form["idSalary"]),
            };
            salaryDao.changeStatus(salaryObj);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}