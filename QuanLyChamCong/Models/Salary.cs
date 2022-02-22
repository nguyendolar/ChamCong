using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyChamCong.Models
{
    public class Salary
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idSalary { get; set; }

        public float salary { get; set; }
        public int month { get; set; }

        public int status { get; set; }

        public int idUser { get; set; }

        public virtual User User { get; set; }
    }
}