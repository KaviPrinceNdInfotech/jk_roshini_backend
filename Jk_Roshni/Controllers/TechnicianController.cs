using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jk_Roshni.Models.Service;
using Jk_Roshni.Models.Entities;
namespace Jk_Roshni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private ITechnician technician;
        public TechnicianController(ITechnician _technician)
        {
            technician = _technician;
        }
        [HttpPost("[action]")]
        public IActionResult AddTechnician(Technician model)
        {
            try
            {
                bool isvalid = technician.AddTechnician(model);
                
                if(isvalid)
                {
                    return Ok(new { status=200,message="Technician Add SuccessFully"});
                }
                else
                {
                    return BadRequest("Technician Not Saved");
                }
            }
            catch
            {
                throw new Exception("Server Error");
            }
        }
        [HttpPost("[action]")]
        public IActionResult ListTechnician()
        {
            try
            {
                var result = technician.TechnicianList();
                if(result !=null)
                {
                    return Ok(new { result, status = 200, message = "No Technician" });
                }
                else
                {
                    return BadRequest("No Technician Available");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
