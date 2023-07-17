using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CgfComparerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgComparerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllResults()
        {
            return Ok();
        }
    }
}
