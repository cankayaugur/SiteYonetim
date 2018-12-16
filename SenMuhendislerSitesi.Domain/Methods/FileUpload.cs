using SenMuhendislerSitesi.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SenMuhendislerSitesi.Domain.Methods
{
    public static class FileUpload
    {
        public static string SaveAndGetFileName(this SlimDto slimDto, string filePath, string prefix = null, int? maxWidth = null, int? maxHeight = null)
        {
            if (slimDto == null)
                return null;

            string base64Image = slimDto.output.image.Substring(slimDto.output.image.IndexOf(',') + 1);
            byte[] byteData = Convert.FromBase64String(base64Image);

            MemoryStream memorystream = new MemoryStream(byteData, 0, byteData.Length);

            Image image;

            if (maxWidth.HasValue && maxHeight.HasValue)
                image = ImageHelper.ImageResize(Image.FromStream(memorystream), maxWidth.Value, maxHeight.Value);
            else if (maxWidth.HasValue)
                image = ImageHelper.ImageResize(Image.FromStream(memorystream), maxWidth.Value);
            else
                image = Image.FromStream(memorystream);

            string fileName = Path.GetFileNameWithoutExtension(slimDto.input.name).ToSeoUrl();

            if (fileName.Length > 150)
                fileName = fileName.Substring(0, 150);

            fileName += DateTime.Now.ToString("mmss");

            if (!string.IsNullOrWhiteSpace(prefix))
                fileName = fileName + prefix;

            fileName += Path.GetExtension(slimDto.input.name);

            var newPath = Path.Combine(HttpContext.Current.Server.MapPath(filePath), fileName); // "~/Dosyalar"

            image.Save(newPath);

            return fileName;
        }

    }
}
