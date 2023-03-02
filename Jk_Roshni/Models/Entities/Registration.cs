using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.Entities
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Servicetype { get; set; }
        public string Password { get; set; }
        public string AadharName { get; set; }        
        public string Rgx { get; set; }
        public int InvoiceNo { get; set; }
    }
}
