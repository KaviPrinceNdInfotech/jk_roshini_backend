using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.ViewModel;
namespace Jk_Roshni.Models.Service
{
   public interface IRegistration
    {
        public int LoginVender(LoginModel model);
        public bool AddRegistration(Registration model);
        public bool Otp(int otpValue);

        public Profile GetProfile(string Rgx);
    }
}
