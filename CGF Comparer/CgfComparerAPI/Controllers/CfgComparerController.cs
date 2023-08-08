using ComparerLibrary;
using CgfComparerAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace CgfComparerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfgComparerController : ControllerBase
    {
        private readonly ICfgComparerService _service;
        public CfgComparerController(ICfgComparerService service)
        {
            _service = service;
        }        

        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [Route("UploadAndCompareFiles")]
        public async Task<IActionResult> UploadAndCompareFiles(IFormFile sourceFile,IFormFile targetFile) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var allData = _service.GetComparedCfgData(sourceFile, targetFile);

            if(!allData.ComparedData.Any()) 
            {
                return BadRequest();
            }
            return Ok(allData);
        } 

        [HttpPost]
        [Route("FilterByIdResults")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FilterByIdAndResults([FromBody] CfgModel cfgData, string? id, [FromQuery] string[] filters)
        {            
            var filteredData = _service.FilterByResultAndId(cfgData, id!, filters);            

            if (filteredData == null || !filteredData.Any())
            {
                return NotFound();
            }

            return Ok(filteredData);
        }

        /*
        [HttpPost]
        [Route("UploadSource")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

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
            var sourceData = service.GetSourceData(file);            

            return Ok(sourceData); 
        }
        [HttpPost]
        [Route("UploadTarget")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
            
            var fileInformation = service.GetTargetData(file);             

            return Ok(fileInformation);
        }

        [HttpGet]
        [Route("FilterById/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FilterByResults(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest();
            }
            var filteredResults = service.FilterByResult(filter);

            if (filteredResults == null || !filteredResults.Any())
            {
                return NotFound();
            }

            return Ok(filteredResults);
        }
        */            
    }
}