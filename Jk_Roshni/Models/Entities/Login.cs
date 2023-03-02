using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.Entities
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(10)")]
        public string Number { get; set; }
        [Column(TypeName ="nvarchar(10)")]
        public string Password { get; set; }
    }
}
