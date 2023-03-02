using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.ViewModel;

namespace Jk_Roshni.Models.Repository
{
    public class RegistrationRepo : IRegistration
    {
        private JkDbContext jkdbcontext;
        public RegistrationRepo(JkDbContext _jkDbContext)
        {
            jkdbcontext = _jkDbContext;
        }
        public bool AddRegistration(Registration model)
        {
            try
            {
                var result = jkdbcontext.registrations.OrderByDescending(x => x.InvoiceNo).FirstOrDefault();
                int invoiceno = Convert.ToInt32(result.InvoiceNo )+ 1;
                Registration emp = new Registration()
                {
                    Name=model.Name,
                    ShopName=model.ShopName.Substring(0,3)+'-'+ invoiceno,
                    AadharName=model.AadharName,
                    Number=model.Number,
                    Password=model.Password,
                    Address=model.Address,
                    Servicetype=model.Servicetype,
                    InvoiceNo=invoiceno,
                    Rgx= Guid.NewGuid().ToString().Substring(0, 25)
            };
                jkdbcontext.registrations.Add(emp);
                jkdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Profile GetProfile(string Rgx)
        {
            try
            {
                var result = jkdbcontext.registrations.Where(x => x.Rgx == Rgx).Select(x => new Profile()
                {
                    Name=x.Name,
                    MobileNo=x.Number,
                    Address=x.Address,
                    Companyname=x.ShopName,
                    Aadhar=x.AadharName,
                    Membershipplan=x.Servicetype,
                }).FirstOrDefault();

                return result;
            }
            catch
            {
                throw new Exception("");
            }
        }

        public int LoginVender(LoginModel model)
        {
            try
            {
                bool isvalid = jkdbcontext.logins.Any(x => x.Number == model.Number && x.Password == model.Password);
               
                
                if(isvalid)
                {
                    var result = jkdbcontext.logins.FirstOrDefault(x => x.Number == model.Number && x.Password == model.Password);

                    if(result !=null)
                    {
                        return result.Id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0; 
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        public bool Otp(int otpValue)
        {
            try
            {
                Otp emp = new Otp()
                {
                    OTP=Convert.ToInt32(otpValue)
                };
                jkdbcontext.otps.Add(emp);
                jkdbcontext.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("");
            }
        }
    }
}
