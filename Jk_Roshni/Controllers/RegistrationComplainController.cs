using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Entities;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.JkDb;
namespace Jk_Roshni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationComplainController : ControllerBase
    {
        private IRegisterComplain _registerComplain;
        public RegistrationComplainController(IRegisterComplain registerComplain)
        {
            _registerComplain = registerComplain;
        }

        [HttpPost("[action]")]
        public IActionResult AddComplain(Ragistration_Complain model)
        {
            try
            {
                bool isAdd =  _registerComplain.AddComplain(model);
                if(isAdd)
                {
                    return Ok(new { status=200,message="Complain Register Successfully"});
                }
                else
                {
                    return BadRequest("Not Complain Register SuccessFully");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }

        [HttpGet("[action]/{MobileNo}")]
        public IActionResult SearchComplain(string MobileNo)
        {
            try
            {
                var result = _registerComplain.GetComplain(MobileNo);
                if(result !=null)
                {
                    return Ok(new { status = 200, message = "Complain List" ,result});
                }
                else
                {
                    return BadRequest("No Complain List");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetComplainList()  //Pending Complain List//
        {
            try
            {
                var result = _registerComplain.GetComplainList();
                if(result !=null)
                {
                    return Ok(new { status = 200, message = "Complain List", result });
                }
                else
                {
                    return BadRequest("No Complain List");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }



        [HttpGet("[action]")]
        public IActionResult GetComplainListClose()  //Close Complain List//
        {
            try
            {
                var result = _registerComplain.GetComplainListClose();
                if (result != null)
                {
                    return Ok(new { status = 200, message = "Complain List", result });
                }
                else
                {
                    return BadRequest("No Complain List");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }



        [HttpGet("[action]")]
        public IActionResult GetComplainListOpen()  //Open Complain List//
        {
            try
            {
                var result = _registerComplain.GetComplainListOpen();
                if (result != null)
                {
                    return Ok(new { status = 200, message = "Complain List", result });
                }
                else
                {
                    return BadRequest("No Complain List");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }


        [HttpGet("[action]/{Rgx}")]
        public IActionResult Invoice(string Rgx)
        {
            try
            {
                var result = _registerComplain.invoice(Rgx);
                if(result !=null)
                {
                    return Ok(new { result, status = "200", message = "Invoice" });
                }
                else
                {
                    return BadRequest("No Invoice");
                }
            }
            catch
            {
                return BadRequest("Server Error");
            }
        }

    }

}
