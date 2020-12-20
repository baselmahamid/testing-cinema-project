using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploadControl
{
    public interface UploadInterface
    {
        public void Uploadfilemultiple(IList<IFormFile> files);



    }
}
