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
        public byte[] GetImgLocationAsync(IFormFile imgInp)
        {
            if (imgInp.Length == 0)
                return null;
    
            using (var ms = new MemoryStream())
            {
                imgInp.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }

    }
}
