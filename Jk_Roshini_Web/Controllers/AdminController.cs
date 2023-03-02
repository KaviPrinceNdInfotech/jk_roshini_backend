using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshini_Web.Models.IServices;
using Jk_Roshni.Models.JkDb;
using Jk_Roshni.Models.ViewModel;
namespace Jk_Roshini_Web.Controllers
{
   [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly IComplain _complain;
        private readonly JkDbContext _context;

        #region --Dependency Injection--
        public AdminController(IComplain _complain,JkDbContext _context)
        {
            this._complain = _complain;
            this._context = _context;
        }
        #endregion --End Dependency Injection--

        #region --Admin DashBoard--
        public IActionResult DashBoard()
        {
            try
            {
                return  View();
            }
            catch (Exception Ex)
            {
                throw new Exception("Erro:" + Ex.Message);
            }

        }
        #endregion

        #region --Admin Complain Close Part--
        public IActionResult ComplainClose()
        {
            try
            {
                var result = _complain.ComplainClose();
                if(result !=null)
                {
                    return View(result);
                }
                else
                {
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
        #endregion

        #region --Admin Complain Open Part--

        public IActionResult ComplainOpen()
        {
            try
            {
                var result = _complain.ComplainOpen();
                if(result !=null)
                {
                    return View(result);
                }
                else
                {
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
        #endregion

        #region --Admin Complain Pending Part--
        public IActionResult ComplainPending()
        {
            try
            {
                var result = _complain.ComplainPending();
                if(result!=null)
                {
                    return View(result);
                }
                else
                {
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
        #endregion

        #region --Admin Complain Status Change--
        [HttpGet]
         public IActionResult StatusChange(int id) //Change Action Method Name//
        {
            try
            {
                var result = _context.ragistration_Complains.FirstOrDefault(x => x.Id == id);
                if(result !=null)
                {
                    return View(result);
                }
                else
                {
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
         }

        [HttpPost]
        public IActionResult StatusChange(ComplainListAdmin model) //Change Action Method Name//
        {
            try
            {
                bool result = _complain.StatusChange(model);
                if(result)
                {
                    return RedirectToAction("");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception Ex)
            {
                throw new Exception("Error:" + Ex.Message);
            }
        }
        #endregion



    }
}
