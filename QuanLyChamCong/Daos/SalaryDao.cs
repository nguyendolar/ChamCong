using QuanLyChamCong.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyChamCong.Daos
{
    public class SalaryDao
    {
        DbContextQl myDb = new DbContextQl();

        public List<Salary> getAll()
        {
            return myDb.salarys.ToList();
        }

        public List<Salary> getUser(int id)
        {
            return myDb.salarys.Where(x => x.idUser == id).ToList();
        }

        public void add(Salary salary)
        {
           myDb.salarys.Add(salary);
           myDb.SaveChanges();
        }

        public void update(Salary salary)
        {
            var obj = myDb.salarys.FirstOrDefault(x => x.idSalary == salary.idSalary);
            obj.salary = salary.salary;
            obj.month = salary.month;
            obj.idUser = salary.idUser;
            myDb.SaveChanges();
        }

        public void changeStatus(Salary salary)
        {
            var obj = myDb.salarys.FirstOrDefault(x => x.idSalary == salary.idSalary);
            obj.status = 1;
            myDb.SaveChanges();
        }
    }
}