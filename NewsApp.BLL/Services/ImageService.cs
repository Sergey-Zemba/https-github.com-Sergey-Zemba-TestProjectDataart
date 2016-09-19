using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.BLL.Interfaces;

namespace NewsApp.BLL.Services
{
    public class ImageService : IImageService
    {
        public string SaveImage(Stream stream, string imageName, string destinationFolder)
        {
            string extension = Path.GetExtension(imageName);
            string serverImageName = Guid.NewGuid() + extension;
            string fullPath = destinationFolder + serverImageName;
            using (FileStream output = new FileStream(fullPath, FileMode.Create))
            {
                stream.CopyTo(output);
            }
            return serverImageName;
        }
    }
}
