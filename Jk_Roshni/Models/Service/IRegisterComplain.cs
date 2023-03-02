using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.ViewModel;
namespace Jk_Roshni.Models.Service
{
    public interface IRegisterComplain
    {
        public bool AddComplain(Ragistration_Complain model);

        public Ragistration_Complain GetComplain(string MobileNo);
        public IEnumerable<ComplainList> GetComplainList();
        public IEnumerable<ComplainList> GetComplainListClose();
        public IEnumerable<ComplainList> GetComplainListOpen();

        public InvoiceModel invoice(string Rgx);

    }
}
