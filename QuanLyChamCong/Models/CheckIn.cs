using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.Models
{
    public class CheckIn
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCheckIn { get; set; }

        public TimeSpan checkIn { get; set; }

        public TimeSpan checkOut { get; set; }

        public TimeSpan timeLate { get; set; }

        public DateTime date { get; set; }

        [StringLength(255)]
        [Required]
        public string reason { get; set; }

        public int status { get; set; }

        [StringLength(255)]
        [Required]
        public string report { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}