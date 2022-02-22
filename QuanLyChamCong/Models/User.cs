using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }

        [StringLength(255)]
        [Required]
        public string fullName { get; set; }

        [StringLength(255)]
        [Required]
        public string userName { get; set; }

        [StringLength(255)]
        [Required]
        public string password { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public string gender { get; set; }

        public int status { get; set; }

        public int idRole { get; set; }

        public int idGroup { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CheckIn> CheckIns { get; set; }

        public virtual ICollection<SupplementalLeave> SupplementalLeaves { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }

        public virtual Group Group { get; set; }
    }
}