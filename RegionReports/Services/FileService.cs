
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using RegionReports.Data.Entities;
using RegionReports.Data.Interfaces;
using RegionReports.Enums;

namespace RegionReports.Services
{
    public class FileService
    {
        private readonly IDbAccessor _database;
        private IJSObjectReference _imageStreamScript;
        private IJSRuntime _jsRuntime;
        private string FileStoragePath = "FileStorage";

        public FileService(IDbAccessor database, IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
            _database = database;

            Task.Run(() => LoadScripts());
        }
        
        private async Task LoadScripts()
        {
            _imageStreamScript = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SetImgFromStream.js");
        }


        public void UploadFile(IBrowserFile file)
        {
             using FileStream fs = new("uploadedfile.tst", FileMode.Create);
                 file.OpenReadStream(file.Size).CopyTo(fs);
        }
        public async Task UploadFileAsync(IBrowserFile file)
        {
            await using FileStream fs = new("uploaded.tst", FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
        }

        public async Task UploadFileAsync(IFormFile file)
        {
            await using FileStream fs = new("uploaded.tst", FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
        }

        //public async Task UploadFilesAsync(IFormFile[] files)
        //{
        //    List<ReportRequestFile> FlieList = new();

        //    foreach (IFormFile file in files)
        //    {
        //        var trustedFileName = Path.GetRandomFileName();

        //        await using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
        //            await file.OpenReadStream().CopyToAsync(fs);

        //        FlieList.Add(new ReportRequestFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName });
        //    }

        //}

        public async Task<List<ReportRequestFile>> UploadFilesAsync(IFormFile[] files)
        {
            List<ReportRequestFile> FlieList = new();

            foreach (IFormFile file in files)
            {
                var trustedFileName = Path.GetRandomFileName();

                await using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
                await file.OpenReadStream().CopyToAsync(fs);

                var uploadedFile = new ReportRequestFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName };

                var fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension.Contains("xls")) uploadedFile.FileType = (int)UploadedFileType.Excel;
                if (fileExtension.Contains("doc")) uploadedFile.FileType = (int)UploadedFileType.Word;
                if (fileExtension.Contains("pdf")) uploadedFile.FileType = (int)UploadedFileType.Pdf;
                
                if (uploadedFile.FileType == 0) uploadedFile.FileType = (int)UploadedFileType.Other;


                FlieList.Add(uploadedFile);

            }

            return FlieList;

        }

        public void DeleteFileFromFileSystem(ReportRequestFile file)
        {
            var path = Path.Combine(FileStoragePath, file.FileUniqueName);

            if (File.Exists(path)) File.Delete(path);
        }
    }
}
