using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.Service;
namespace Jk_Roshni.Models.Repository
{
    public class TechnicianRepo : ITechnician
    {
        private JkDbContext jkdbcontext;
        public TechnicianRepo(JkDbContext _jkDbContext)
        {
            jkdbcontext = _jkDbContext;
        }
        public bool AddTechnician(Technician model)
        {
            try
            {
                Technician emp = new Technician()
                {
                    Name=model.Name,
                    Mobile=model.Mobile,
                    Address=model.Address
                };
                jkdbcontext.technicians.Add(emp);
                jkdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }

        public IEnumerable<Technician> TechnicianList()
        {
            try
            {
                var result = jkdbcontext.technicians.ToList();              
                return result;             
               
            }
            catch(Exception ex)
            {
                throw new Exception("Error"+ex.Message);
            }
        }
    }
}
