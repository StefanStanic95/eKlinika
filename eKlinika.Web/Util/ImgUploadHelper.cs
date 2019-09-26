using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Util.FileManager;

namespace eKlinika.Util
{
    public class ImgUploadHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileManager _fileManager;
        public ImgUploadHelper(IHostingEnvironment he,IFileManager manager)
        {
            _hostingEnvironment = he;
            _fileManager = manager;
        }


        public byte[] GetImgLocationAsync(IFormFile imgInp)
        {
            return new byte[100];
        }

    }
}
