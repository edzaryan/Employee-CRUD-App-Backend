﻿using EmployeeApp.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeApp.Services.Repositories
{
    public class CustomFileMethods : IFileCustomFunctions
    {
        private readonly IWebHostEnvironment _env;

        public CustomFileMethods(IWebHostEnvironment env) => _env = env;

        public async Task<string> UploadFileAsync(IFormFile file, string directoryName)
        {
            string uploadsDirectoryName = $"{_env.WebRootPath}\\{directoryName}";

            string uniqueFileName = $"{UniqueStringGenerator(10)}{Path.GetExtension(file.FileName)}";

            string filePath = $"{uploadsDirectoryName}\\{uniqueFileName}";

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return uniqueFileName;
        }

        public void DeleteFile(string fileName, string directoryName)
        {
            string fullFilePath = $"{_env.WebRootPath}\\{directoryName}\\{fileName}";

            if (File.Exists(fullFilePath))
            {
                File.Delete(fullFilePath);
            }
        }

        public string UniqueStringGenerator(int length)
        {
            Random random = new Random();

            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string uniqueString = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return uniqueString;
        }
    }
}
