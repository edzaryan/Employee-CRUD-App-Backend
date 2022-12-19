namespace EmployeeApp.Services.Interfaces
{
    public interface IFileCustomFunctions
    {
        Task<string> UploadFileAsync(IFormFile file, string directoryName);

        void DeleteFile(string fileName, string directoryName);
    }
}
