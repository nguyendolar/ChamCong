using QuanLyChamCong.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyChamCong.Daos
{
    public class CheckInDao
    {
        DbContextQl myDb = new DbContextQl();
        public List<CheckIn> getAll()
        {
            return myDb.checkIns.OrderByDescending(x => x.date).ToList();
        }

        public List<CheckIn> getCheckInUser(int id)
        {
            return myDb.checkIns.Where(x => x.idUser == id).OrderByDescending(x => x.date).ToList();
        }

        public void add(CheckIn checkIn)
        {
            myDb.checkIns.Add(checkIn);
            myDb.SaveChanges();
        }

        public List<SupplementalLeave> getSup()
        {
            return myDb.supplementalLeaves.OrderByDescending(x => x.date).ToList();
        }

        public List<SupplementalLeave> getSupUser(int id)
        {
            return myDb.supplementalLeaves.Where(x => x.idUser == id).OrderByDescending(x => x.date).ToList();
        }
        public void approve(SupplementalLeave supplementalLeave)
        {
            var obj = myDb.supplementalLeaves.FirstOrDefault(x => x.idSupplementalLeave == supplementalLeave.idSupplementalLeave);
            obj.status = 1;
            myDb.SaveChanges();
        }

        public void addSupp(SupplementalLeave supplementalLeave)
        {
            myDb.supplementalLeaves.Add(supplementalLeave);
            myDb.SaveChanges();
        }
        public void editSupp(SupplementalLeave supplementalLeave)
        {
            var obj = myDb.supplementalLeaves.FirstOrDefault(x => x.idSupplementalLeave == supplementalLeave.idSupplementalLeave);
            obj.idType = supplementalLeave.idType;
            obj.date = supplementalLeave.date;
            obj.checkIn = supplementalLeave.checkIn;
            obj.checkOut = supplementalLeave.checkOut;
            obj.reason = supplementalLeave.reason;
            myDb.SaveChanges();
        }

        public List<Models.Type> getType()
        {
            return myDb.types.ToList();
        }
    }
}