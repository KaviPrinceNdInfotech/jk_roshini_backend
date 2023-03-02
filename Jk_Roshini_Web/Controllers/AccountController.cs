using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.ViewModel;
using Jk_Roshini_Web.Models.IServices;
namespace Jk_Roshini_Web.Controllers
{    
    public class AccountController : Controller
    {
        public IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        /// <summary>
        ///   Admin Login
        /// </summary>
      
        [HttpGet]
        public IActionResult Login()
        {
            try
            {
                return  View();
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Login(AdminLoginModel model)
        {
            try
            {
                bool isvalid =  _account.Login(model);
                if(isvalid)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ModelState.Clear();                   
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
    

        public IActionResult demo()
        {
            return View();
        }
    }
}
