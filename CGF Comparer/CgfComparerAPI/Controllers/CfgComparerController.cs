using CGF_Comparer;
using CgfComparerAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        
    }
}
