using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idReview { get; set; }

        [Required]
        public string content { get; set; }

        public int status { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}