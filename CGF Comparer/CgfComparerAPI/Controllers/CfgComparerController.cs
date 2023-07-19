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
            var allData = service.GetComparedData();            

            if(allData == null || !allData.Any()) 
            {
                return NoContent();
            }

            return Ok(allData);
        }
        [HttpPost]
        [Route("UploadSource")]
        public async Task<IActionResult> UploadSource(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file");
            }
            var extension = Path.GetExtension(file.FileName);

            if (extension != ".cfg")
            {
                return BadRequest("Please select a cfg file");
            }
            
            var b = service.GetSourceData(file);            

            return Ok(b); 
        }
        [HttpPost]
        [Route("UploadTarget")]
        public async Task<IActionResult> UploadTarget(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file");
            }
            var extension = Path.GetExtension(file.FileName);

            if (extension != ".cfg")
            {
                return BadRequest("Please select a cfg file");
            }
            
            service.GetTargetData(file);            

            return Ok();
        }
        [HttpGet]
        [Route("FilterById")]
        public async Task<IActionResult> FilterById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var filteredResults = service.FilterById(id);

            if(!filteredResults.Any()) 
            {
                return NotFound();
            }

            return Ok(filteredResults);
        }
        [HttpGet]
        [Route("FilterByResult")]
        public async Task<IActionResult> FilterByResults(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest();
            }
            var filteredResults = service.FilterByResult(filter);

            if (!filteredResults.Any())
            {
                return NotFound();
            }

            return Ok(filteredResults);
        }
    }
}
