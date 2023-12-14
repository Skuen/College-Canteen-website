using Microsoft.AspNetCore.Http;

namespace CanteenCollegeAPI.Services.Interfaces
{
    public interface IFileService
    {
        public string SaveFile(IFormFile formFile);
        void Delete(string name);
        public byte[] GetFile(string filename);
    }
}
