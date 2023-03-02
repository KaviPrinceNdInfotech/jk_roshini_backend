using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshini_Web.Models.IServices;
using Jk_Roshni.Models.ViewModel;
using Jk_Roshni.Models.JkDb;
namespace Jk_Roshini_Web.Models.Repository
{
    public class AccountRepo : IAccount
    {
        private  JkDbContext _context;
        public AccountRepo(JkDbContext context)
        {
            _context = context;
        }
        public bool Login(AdminLoginModel model)
        {
            try
            {
                bool isvalid =  _context.adminLogins.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if(isvalid)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
    }
}
