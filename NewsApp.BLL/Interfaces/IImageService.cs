using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.BLL.Interfaces
{
    public interface IImageService
    {
        string SaveImage(Stream stream, string imageName, string destinationFolder);
    }
}
