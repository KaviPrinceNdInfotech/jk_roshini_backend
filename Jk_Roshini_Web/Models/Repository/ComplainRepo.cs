using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshini_Web.Models.IServices;
using Jk_Roshni.Models.ViewModel;
using Jk_Roshni.Models.JkDb;
namespace Jk_Roshini_Web.Models.Repository
{
    public class ComplainRepo : IComplain
    {
        private readonly JkDbContext _context;
        public ComplainRepo(JkDbContext context)
        {
            _context = context;
        }
        public List<ComplainListAdmin> ComplainClose()
        {
            try
            {
                var result = _context.ragistration_Complains.Where(x=>x.Status=="Close").Select(x => new ComplainListAdmin()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Mobile=x.Mobile,
                    Address=x.Address,
                    ServiceType=x.TypeOfServices,
                    Status=x.Status,
                    ProductName= (from p in _context.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        public List<ComplainListAdmin> ComplainOpen()
        {
            try
            {

                var result = _context.ragistration_Complains.Where(x => x.Status == "Open").Select(x => new ComplainListAdmin()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Address = x.Address,
                    ServiceType = x.TypeOfServices,
                    Status = x.Status,
                    ProductName = (from p in _context.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }

        public List<ComplainListAdmin> ComplainPending()
        {
            try
            {
                var result = _context.ragistration_Complains.Where(x => x.Status == "Pending").Select(x => new ComplainListAdmin()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Address = x.Address,
                    ServiceType = x.TypeOfServices,
                    Status = x.Status,
                    ProductName = (from p in _context.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }

        public bool StatusChange(ComplainListAdmin model)
        {
            try
            {
                var result = _context.ragistration_Complains.FirstOrDefault(x => x.Id == model.Id);
                if(result !=null)
                {
                    result.Status = model.Status;
                }
                _context.SaveChanges();
                return true;
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
    }
}
