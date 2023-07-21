﻿using CgfComparerAPI.Service;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
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
            
            service.GetTargetData(file);            

            return Ok();
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

        [HttpGet]
        [Route("FilterByIdResults")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FilterByIdAndResults(string id, [FromQuery] string[] filters)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var filteredData = service.FilterByResultAndId(id, filters);            

            if (filteredData == null || !filteredData.Any())
            {
                return NotFound();
            }

            return Ok(filteredData);
        }
    }
}