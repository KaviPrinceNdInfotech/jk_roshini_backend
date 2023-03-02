using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Jk_Roshni.Models.ViewModel;

namespace Jk_Roshini_Web.Models.IServices
{
    public interface IComplain
    {
        public List<ComplainListAdmin> ComplainClose();

        public List<ComplainListAdmin> ComplainOpen();

        public List<ComplainListAdmin> ComplainPending();

        public bool StatusChange(ComplainListAdmin model);
    }
}
