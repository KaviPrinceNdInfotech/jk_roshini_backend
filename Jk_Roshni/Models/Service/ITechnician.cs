using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
namespace Jk_Roshni.Models.Service
{
    public interface ITechnician
    {
        public bool AddTechnician(Technician model);

        public IEnumerable<Technician> TechnicianList();
    }
}
