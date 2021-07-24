using Svg;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace mRemoteNG
{
    class ImageConverter
    {
        internal static Bitmap GetImageAsBitmap(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            {
                var svgDocument = SvgDocument.Open(stream.ToString());
                var bitmap = svgDocument.Draw();
                return bitmap;
            }
        }

        internal static Icon GetImageAsIcon(byte[] byteArray)
        {
            var bitmap = GetImageAsBitmap(byteArray);
            // Convert to an icon and use for the form's icon.
            var icon = Icon.FromHandle(bitmap.GetHicon());
            // Destroy icon handle to prevent memory leaks
            DestroyIcon(icon.Handle);

            return icon;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
    }
}
