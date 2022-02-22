using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChamCong.Daos
{
    public class GroupDao
    {
        DbContextQl myDb = new DbContextQl();

        public List<Group> getAll()
        {
            return myDb.groups.ToList();
        }

        public void add(Group group)
        {
           myDb.groups.Add(group);
           myDb.SaveChanges();
        }

        public void delete(int id)
        {
           var obj = myDb.groups.FirstOrDefault(x => x.idGroup == id);
           myDb.groups.Remove(obj);
           myDb.SaveChanges();
        }

        public void update(Group group)
        {
            var obj = myDb.groups.FirstOrDefault(x => x.idGroup == group.idGroup);
            obj.name = group.name;
            myDb.SaveChanges();
        }
    }
}