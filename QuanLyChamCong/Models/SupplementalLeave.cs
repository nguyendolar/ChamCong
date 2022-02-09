using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.Models
{
    public class SupplementalLeave
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSupplementalLeave { get; set; }

        public TimeSpan checkIn { get; set; }

        public TimeSpan checkOut { get; set; }

        public TimeSpan timeLate { get; set; }

        public DateTime date { get; set; }

        [StringLength(255)]
        [Required]
        public string reason { get; set; }

        public int status { get; set; }

        public int idType { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }

        public virtual Type Type { get; set; }

    }
}