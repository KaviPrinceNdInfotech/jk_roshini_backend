using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.Entities
{
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="varchar(30)")]
        public string UserName { get; set; }
        [Column(TypeName ="nvarchar(30)")]
        public string Password { get; set; }
        [Column(TypeName ="varchar(10)")]
        public string Role { get; set; }
    }
}
