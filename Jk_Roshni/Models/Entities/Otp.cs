using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.Entities
{
    public class Otp
    {
        [Key]
        public int id { get; set; }
        public int OTP { get; set; }
    }
}
