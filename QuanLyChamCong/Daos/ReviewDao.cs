using QuanLyChamCong.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyChamCong.Daos
{
    public class ReviewDao
    {
        DbContextQl myDb = new DbContextQl();

        public void add(Review review)
        {
            myDb.reviews.Add(review);
            myDb.SaveChanges();
        }
        public List<Review> getListReviewByUser(int idUser)
        {
            return myDb.reviews.Where(x => x.idUser == idUser).ToList();
        }
    }
}