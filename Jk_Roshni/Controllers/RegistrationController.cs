using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.ViewModel;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.Utilities;
using Jk_Roshni.Models.JkDb;
namespace Jk_Roshni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistration registration;
        private JkDbContext _obj;
        public RegistrationController(IRegistration _registration , JkDbContext obj)
        {
            registration = _registration;
            _obj = obj;
        }

        [HttpPost("[action]")]
        public IActionResult MobileOtp(MobileOTP model)
        {
            try
            {
                int otpValue = new Random().Next(1000, 9999);
                string msg = "Dear User, \n";
                msg += "Your OTP for login to Gyros is " + otpValue + ". Valid for 30 minutes. Please do not share this OTP.\n";
                msg += "Regards,\n";
                msg += "Gyros Team";
                string dltid = "1207166254332687769";
                Mobile.SendSms(model.MobileNo, msg, dltid);
                  this.HttpContext.Response.Cookies.Append("OtpValue", otpValue.ToString(), new CookieOptions { Expires = DateTimeOffset.Now.AddMinutes(30), Path = "/" });
                bool isvalid =  registration.Otp(otpValue);

                return Ok("OTP Send SuccessFully");                

               
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }

        [HttpPost("[action]")]
        public IActionResult OtpVerify(MobileOTP model)
        {
            try
            {
                if(model.Otp !=null)
                {
                    //if (this.HttpContext.Request.Cookies.ContainsKey("OtpValue") != false)
                    //{
                    //    var cookiesname = this.HttpContext.Request.Cookies["OtpValue"];
                    //    if (model.Otp == cookiesname)
                    //    {
                    //        return Ok(new { status = 200, message = "OTP Verify Successfully" });
                    //    }
                    //}
                    var result = _obj.otps.FirstOrDefault(x => x.OTP == Convert.ToInt32(model.Otp));
                    if (result != null)
                    {
                        _obj.otps.Remove(result);
                        _obj.SaveChanges();
                        return Ok(new { status = 200, message = "OTP Verify Successfully" });

                    }
                    else
                    {
                        return BadRequest("OTP Verify Not SuccessFully");
                    }

                }               
                return BadRequest("OTP invalid");
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }
   
    
       [HttpPost("[action]")]
       public IActionResult Registration(Registration model)
        {
            try
            {
                bool isadd = registration.AddRegistration(model);
                if(isadd)
                {
                    return Ok(new { status = 200, message = "Registration SuccessFully" });
                }
                else
                {
                    return BadRequest("Registration UnSuccessFully");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }

        }
    

        [HttpGet("[action]/{Rgx}")]
        public IActionResult GetProfile(string Rgx)
        {
            try
            {
                var result = registration.GetProfile(Rgx);
                if(result !=null)
                {
                    return Ok(new { status = 200, message = "Profile", result });
                }
                else
                {
                    return BadRequest("No Data Available");
                }
               
            }
            catch
            {
                return BadRequest("Server Error");
            }
        } 

        [HttpPost("[action]")]
        public IActionResult LoginVender(LoginModel model)
        {
            try
            {
                int result = registration.LoginVender(model);
                if(result >0)
                {
                    var venderdata = _obj.registrations.FirstOrDefault(x => x.Id == result);
                    if(venderdata !=null)
                    {
                        return Ok(new { venderdata, status = 200, message = "Login SuccessFully" });
                    }
                    else
                    {
                        return BadRequest("Invalid Login");
                    }
                }
                else
                {
                    return BadRequest("Invalid Login");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }
        

    }
}
