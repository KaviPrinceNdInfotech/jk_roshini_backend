using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.ViewModel;
namespace Jk_Roshni.Models.Repository
{
    public class RegisterComplainRepo : IRegisterComplain
    {
        private JkDbContext _obj;
        public RegisterComplainRepo(JkDbContext obj)
        {
            _obj = obj;
        }       
        public bool AddComplain(Ragistration_Complain model)
        {
            try
            {
                Ragistration_Complain emp = new Ragistration_Complain()
                {
                   Name=model.Name,
                   Mobile=model.Mobile,
                   ProductId=model.ProductId,
                   Address=model.Address,
                   TypeOfServices=model.TypeOfServices,
                   Rgx=model.Rgx,
                   Status="pending"
                };
                _obj.ragistration_Complains.Add(emp);
                _obj.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Ragistration_Complain GetComplain(string MobileNo)
        {
            try
            {
                var result = _obj.ragistration_Complains.Where(x => x.Mobile == MobileNo).FirstOrDefault();
                return result;
            }
            catch
            {
                throw new Exception("");
            }
        }

        public IEnumerable<ComplainList> GetComplainList()   //Pending//
        {
            try
            {
                var result = _obj.ragistration_Complains.Where(x=>x.Status== "Pending").Select(x => new ComplainList()
                {
                    Name=x.Name,
                    Mobile=x.Mobile,
                    Address=x.Address,
                    TypeOfService=x.TypeOfServices,
                    Status=x.Status,
                    Services = (from p in _obj.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch {
                throw new Exception("");
            }
        }



        public IEnumerable<ComplainList> GetComplainListClose()   //Close//
        {
            try
            {
                var result = _obj.ragistration_Complains.Where(x => x.Status == "Close").Select(x => new ComplainList()
                {
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Address = x.Address,
                    TypeOfService = x.TypeOfServices,
                    Status = x.Status,
                    Services = (from p in _obj.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch
            {
                throw new Exception("");
            }
        }


        public IEnumerable<ComplainList> GetComplainListOpen()   //Open//
        {
            try
            {
                var result = _obj.ragistration_Complains.Where(x => x.Status == "Open").Select(x => new ComplainList()
                {
                    Name = x.Name,
                    Mobile = x.Mobile,
                    Address = x.Address,
                    TypeOfService = x.TypeOfServices,
                    Status = x.Status,
                    Services = (from p in _obj.products where p.Id == x.ProductId select p.Name).FirstOrDefault()
                }).ToList();
                return result;
            }
            catch
            {
                throw new Exception("");
            }
        }

        public InvoiceModel invoice(string Rgx)
        {
            try
            {
                var result = (from inv in _obj.registrations
                              join r1 in _obj.ragistration_Complains on inv.Rgx equals r1.Rgx
                              join p1 in _obj.products on r1.ProductId equals p1.Id where inv.Rgx==Rgx
                              select new InvoiceModel()
                              {
                                  Id=inv.Id,
                                  InvoiceNo=inv.InvoiceNo,
                                  Name=inv.Name,
                                  AadharName=inv.AadharName,
                                  Address=inv.Address,
                                  Status=r1.Status,
                                  Servicetype=r1.TypeOfServices,
                                  ShopName=inv.ShopName,
                                  ProductName = p1.Name,
                                  Number=inv.Number
                              }).FirstOrDefault();
                return result;
            }
            catch
            {
                throw new Exception("");
            }
        }
    }
}
