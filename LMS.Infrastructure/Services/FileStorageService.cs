namespace LMS.Infrastructure.Services
{
    public class FileStorageService
    {
        private readonly string _uploadPath;

        public FileStorageService(string uploadPath = "Uploads")
        {
            _uploadPath = uploadPath;
            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }
        }

        public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
        {
            var filePath = Path.Combine(_uploadPath, fileName);
            using var outputStream = new FileStream(filePath, FileMode.Create);
            await fileStream.CopyToAsync(outputStream);
            return filePath;
        }

        public bool DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
