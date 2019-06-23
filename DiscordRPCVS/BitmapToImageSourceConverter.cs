using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DiscordRPCVS
{
    public class BitmapToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Bitmap bitmap))
                return null;

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                int size = rect.Width * rect.Height * 4;

                return BitmapSource.Create(bitmap.Width, bitmap.Height, bitmap.HorizontalResolution, bitmap.VerticalResolution, PixelFormats.Bgra32, null, bitmapData.Scan0, size, bitmapData.Stride);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}