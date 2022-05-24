
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
        private IJSObjectReference _fileDownloadScript;
        private IJSRuntime _jsRuntime;
        private readonly string FileStoragePath;

        public FileService(IDbAccessor database, IJSRuntime jsRuntime, SettingsService settingsService)
        {
            _jsRuntime = jsRuntime;
            _database = database;
            FileStoragePath = settingsService.GetFileStoragePath();

            Task.Run(() => LoadScripts());
        }
        
        private async Task LoadScripts()
        {
            _imageStreamScript = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/SetImgFromStream.js");
            _fileDownloadScript = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", @"/js/FileStreamDownload.js");
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

        public async Task<ReportRequestFile> UploadFileAsync(IFormFile file)
        {
            var trustedFileName = Path.GetRandomFileName();

            using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
                await file.OpenReadStream().CopyToAsync(fs);

            var uploadedFile = new ReportRequestFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName };

            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Contains("xls")) uploadedFile.FileType = (int)UploadedFileType.Excel;
            if (fileExtension.Contains("doc")) uploadedFile.FileType = (int)UploadedFileType.Word;
            if (fileExtension.Contains("pdf")) uploadedFile.FileType = (int)UploadedFileType.Pdf;

            if (uploadedFile.FileType == 0) uploadedFile.FileType = (int)UploadedFileType.Other;

            return uploadedFile;
        }


        public async Task<ReportRequestTemplateFile> UploadTemplateFileAsync(IFormFile file)
        {
            var trustedFileName = Path.GetRandomFileName();

            using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            var uploadedFile = new ReportRequestTemplateFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName };

            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Contains("xls")) uploadedFile.FileType = (int)UploadedFileType.Excel;
            if (fileExtension.Contains("doc")) uploadedFile.FileType = (int)UploadedFileType.Word;
            if (fileExtension.Contains("pdf")) uploadedFile.FileType = (int)UploadedFileType.Pdf;

            if (uploadedFile.FileType == 0) uploadedFile.FileType = (int)UploadedFileType.Other;

            return uploadedFile;
        }

        public async Task<ResponseFile> UploadResponseFileAsync(IFormFile file)
        {
            var trustedFileName = Path.GetRandomFileName();

            using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            var uploadedFile = new ResponseFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName };

            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension.Contains("xls")) uploadedFile.FileType = (int)UploadedFileType.Excel;
            if (fileExtension.Contains("doc")) uploadedFile.FileType = (int)UploadedFileType.Word;
            if (fileExtension.Contains("pdf")) uploadedFile.FileType = (int)UploadedFileType.Pdf;

            if (uploadedFile.FileType == 0) uploadedFile.FileType = (int)UploadedFileType.Other;

            return uploadedFile;
        }

        /// <summary>
        /// Синхронная загрузка нескольких файлов
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public List<ReportRequestFile> UploadFiles(IFormFile[] files)
        {
            List<ReportRequestFile> fileList = new();

            foreach (IFormFile file in files)
            {
                var trustedFileName = Path.GetRandomFileName();

                using FileStream fs = new(Path.Combine(FileStoragePath, trustedFileName), FileMode.Create);
                    file.OpenReadStream().CopyToAsync(fs);

                var uploadedFile = new ReportRequestFile() { FileUniqueName = trustedFileName, FileOriginalName = file.FileName };

                var fileExtension = Path.GetExtension(file.FileName);

                if (fileExtension.Contains("xls")) uploadedFile.FileType = (int)UploadedFileType.Excel;
                if (fileExtension.Contains("doc")) uploadedFile.FileType = (int)UploadedFileType.Word;
                if (fileExtension.Contains("pdf")) uploadedFile.FileType = (int)UploadedFileType.Pdf;

                if (uploadedFile.FileType == 0) uploadedFile.FileType = (int)UploadedFileType.Other;


                fileList.Add(uploadedFile);

            }

            return fileList;

        }

        /// <summary>
        /// Асинхронная загрузка нескольких файлов
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<List<ReportRequestFile>> UploadFilesAsync(IFormFile[] files)
        {
            List<ReportRequestFile> fileList = new();

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


                fileList.Add(uploadedFile);

            }

            return fileList;

        }

        public void DeleteFileFromFileSystem(ReportFileBase file)
        {
            var path = Path.Combine(FileStoragePath, file.FileUniqueName);

            if (File.Exists(path)) File.Delete(path);
        }

        public async Task DownloadFileFromServer(ReportFileBase requestFile)
        {
            var filePathWithUniqueName = Path.Combine(FileStoragePath, requestFile.FileUniqueName);

            if (File.Exists(filePathWithUniqueName))
            {
                var fileStream = new FileStream(filePathWithUniqueName, FileMode.Open);
                if (fileStream != null)
                {
                    using var streamRef = new DotNetStreamReference(fileStream);
                    //await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
                    await _fileDownloadScript.InvokeVoidAsync("downloadFileFromStream",  requestFile.FileOriginalName, streamRef);
                }
            }

        }
    }
}
