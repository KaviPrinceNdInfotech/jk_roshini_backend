using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.ViewModel;
namespace Jk_Roshini_Web.Models.IServices
{
    public interface IAccount
    {
        public bool Login(AdminLoginModel model);
    }
}
