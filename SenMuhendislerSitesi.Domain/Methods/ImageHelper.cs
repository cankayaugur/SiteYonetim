using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.Methods
{
    public static class ImageHelper
    {


        public static Bitmap ImageResize(Image image, int maxWidth, int maxHeight)
        {
            var originalImage = new Bitmap(image);

            var newImage = new Bitmap(originalImage, maxWidth, maxHeight);

            var g = Graphics.FromImage(newImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);

            originalImage.Dispose();

            return newImage;
        }

        public static Bitmap ImageResize(Image image, int maxWidth)
        {
            var originalImage = new Bitmap(image);

            double newWidth = image.Width;
            double newHeight = image.Height;
            if (newWidth > maxWidth)
            {
                double ratio = newWidth / newHeight;
                newHeight = maxWidth / ratio;
                newWidth = maxWidth;
            }

            var newImage = new Bitmap(originalImage, Convert.ToInt32(newWidth), Convert.ToInt32(newHeight));

            var g = Graphics.FromImage(newImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);

            originalImage.Dispose();

            return newImage;
        }
    }
}
