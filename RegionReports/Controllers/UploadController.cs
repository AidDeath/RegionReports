using Microsoft.AspNetCore.Mvc;
using RegionReports.Services;

namespace RegionReports.Controllers
{
    public partial class UploadController : Controller
    {

        private FileService _fileService;
        public UploadController(FileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload/single")]
        public async Task<IActionResult> Single(IFormFile file)
        {
            try
            {
                if (file is null) return BadRequest();
                await _fileService.UploadFileAsync(file);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/multiple")]
        public IActionResult Multiple(IFormFile[] files)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/{id}")]
        public IActionResult Post(IFormFile[] files, int id)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
