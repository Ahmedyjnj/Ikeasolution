using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Common.Services.Attachments
{
    public class AttachmentServices : IAttachmentServices
    {
        private readonly List<string> AllowedExtensions = new List<string>
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif"
        };
        private const int FileMaximumsize = 2_097_152; // 5 MB  5 * 1024 * 1024
        //this is 2mb size

        //after we make a extention and sizze allowed we will implement
        public string UploadImage(IFormFile file, string FolderName)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (!AllowedExtensions.Contains(fileExtension))
            {
                throw new Exception("invalid file Extension");
            }
            if (file.Length>FileMaximumsize)
            {
                throw new Exception("invalid file size ,over our range !!");
            }

            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files",FolderName);
            //this current directory path better than local path

            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            //in images we should make name unique to prevent replace by Guid

            var FileName = $"{Guid.NewGuid()}_{file.FileName}";

            var FilePath =Path.Combine(FolderPath,FileName);


            //filestream is from things that clr can not automatic 
            //controll it we should make it 

            using var fs = new FileStream(FilePath, FileMode.Create);
           
            file.CopyTo(fs); //by this we will give a stream a file

            //fs.Close(); //this is important to close the stream
            //but using will close connection automatic



            return FileName;




        }
        //we need to make security for only extention of photo
        //now time for filestream
        public bool DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

     //we make service to image now
    }
}


