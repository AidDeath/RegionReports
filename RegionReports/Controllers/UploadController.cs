using Microsoft.AspNetCore.Mvc;
using RegionReports.Services;

namespace RegionReports.Controllers
{
    public partial class UploadController : Controller
    {

        private FileService _fileService;
        private readonly long _maxFileSize;
        public UploadController(FileService fileService, SettingsService settingsService)
        {
            _fileService = fileService;
            _maxFileSize = settingsService.GetMaxUploadFileSize();
        }

        [HttpPost("upload/single")]
        public async Task<IActionResult> Single(IFormFile file)
        {
            try
            {
                if (file.Length > _maxFileSize) throw new Exception("Превышено ограничение на размер файла");
                var uploadedFile = await _fileService.UploadFileAsync(file);
                return Ok(uploadedFile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        [HttpPost("upload/singletemplate")]
        public async Task<IActionResult> SingleTemplate(IFormFile file)
        {
            try
            {
                if (file.Length > _maxFileSize) throw new Exception("Превышено ограничение на размер файла");
                var uploadedFile = await _fileService.UploadTemplateFileAsync(file);
                return Ok(uploadedFile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        
        [HttpPost("upload/singlefileresponse")]
        public async Task<IActionResult> SingleResponse(IFormFile file)
        {
            try
            {
                if (file.Length > _maxFileSize) throw new Exception("Превышено ограничение на размер файла");
                var uploadedFile = await _fileService.UploadResponseFileAsync(file);
                return Ok(uploadedFile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("upload/multiple")]
        public async Task<IActionResult> Multiple(IFormFile[] files)
        {
            try
            {
                if (files.Max(f => f.Length) > _maxFileSize) throw new Exception("Превышено ограничение на размер файла");

                var uploadedFiles = await _fileService.UploadFilesAsync(files);
                //return StatusCode(200);
                return Ok(uploadedFiles);
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
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
