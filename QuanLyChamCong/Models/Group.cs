using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyChamCong.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idGroup { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}