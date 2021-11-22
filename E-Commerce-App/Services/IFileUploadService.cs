using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMvc.Services
{
    public interface IFileUploadService
    {
        Task<string> Upload(IFormFile file);
    }

    public class JarenFileUploadService : IFileUploadService
    {
        public async Task<string> Upload(IFormFile file)
        {
            return "https://avatars.githubusercontent.com/u/77555177?s=400&u=337f1f4f25cc02f85135569e5806e85de0775e15&v=4";
        }
    }
}
