using CanteenCollegeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CanteenCollegeAPI.Services.Implements
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string abspath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Images");
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string SaveFile(IFormFile formFile)
        {
            string name = Path.Combine( DateTime.Now.ToString("yyyy-MM-dd") + "_" +  Guid.NewGuid() + "_" + formFile.FileName);
            
            if (!Directory.Exists(abspath))
                Directory.CreateDirectory(abspath);
            Save(Path.Combine(abspath, name), formFile).GetAwaiter();
            return name;
        }
        public async Task Save(string path, IFormFile file)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                stream.Close();
            }           
        }
        public void Delete(string name)
        {
            var path = Path.Combine(abspath, name);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public byte[] GetFile(string filename)
        {
            string filepath = Path.Combine(abspath,filename);
            if(File.Exists(filepath))
            {
                byte[] byteArray = File.ReadAllBytes(filepath);
                return byteArray;
                
            }
            return null;
        }
    }
}
