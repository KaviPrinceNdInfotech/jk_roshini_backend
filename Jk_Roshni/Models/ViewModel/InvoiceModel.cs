using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jk_Roshni.Models.ViewModel
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string Servicetype { get; set; }     
        public string AadharName { get; set; }
               
        public string ProductName { get; set; }
        public string Status { get; set; }
       
        public int InvoiceNo { get; set; }
    }
}
