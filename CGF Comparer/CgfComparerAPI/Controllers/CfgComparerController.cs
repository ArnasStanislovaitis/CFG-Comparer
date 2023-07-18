using CGF_Comparer;
using CgfComparerAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CgfComparerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgComparerController : ControllerBase
    {
        private readonly ICfgComparerService service;
        public CfgComparerController(ICfgComparerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResults()
        {
            var a = service.GetComparedData();            

            return Ok(a);
        }
        [HttpPost]
        [Route("UploadSource")]
        public async Task<IActionResult> UploadSource(IFormFile file)
        {

            var a = service.ReadFile(file);
            var b = service.GetSourceData(file);

            if (b == null || b.Count()<1)
            {
                return BadRequest();
            }     

            return Ok(b); 
        }
        [HttpPost]
        [Route("UploadTarget")]
        public async Task<IActionResult> UploadTarget(IFormFile file)
        {

            var a = service.ReadFile(file);
            service.GetTargetData(file);

            if (a == null)
            {
                return BadRequest();
            }

            return Ok(a);
        }
    }
}
