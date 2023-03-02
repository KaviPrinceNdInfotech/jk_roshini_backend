using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.Entities
{
    public class Ragistration_Complain
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int ProductId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string TypeOfServices { get; set; }
        public string Rgx { get; set; }
        public int TechnicianId { get; set; }

        public int VenderId { get; set; }
    }
}
