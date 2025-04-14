using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Common.Services.Attachments
{
    public interface IAttachmentServices
    {

        /// <summary>
        /// Uploads a file to the server and returns the file path.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <returns>The file path of the uploaded file.</returns>
        public string UploadImage(IFormFile file,string FolderName);

        //we will install by ctrl+. the package call features to use Iformfile


        /// <summary>
        /// Deletes a file from the server.
        /// </summary>
        /// <param name="filePath">The file path of the file to delete.</param>
        public bool DeleteImage(string filePath);
    }
}
