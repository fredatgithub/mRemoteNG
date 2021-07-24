using Svg;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace mRemoteNG
{

    class ImageConverter
    {

        #region Private Methods

        private static Bitmap Convert(string SVGString)
        {
            var svgDocument = SvgDocument.FromSvg<SvgDocument>(SVGString);
            var bitmap = svgDocument.Draw();

            return bitmap;
        }

        private static Bitmap Convert(string SVGString, int Height, int Width)
        {
            var svgDocument = SvgDocument.FromSvg<SvgDocument>(SVGString);
            svgDocument.Height = Height;
            svgDocument.Width = Width;
            var bitmap = svgDocument.Draw();

            return bitmap;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Draws a Bitmap from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Bitmap GetImageAsBitmap(string SVGString)
        {
            return Convert(SVGString);
        }

        /// <summary>
        /// Draws a sqare Bitmap from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Bitmap GetImageAsBitmap(string SVGString, int Size)
        {
            return Convert(SVGString, Size, Size);
        }

        /// <summary>
        /// Draws a sized Bitmap from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Bitmap GetImageAsBitmap(string SVGString, int Height, int Width)
        {
            return Convert(SVGString, Height, Width);
        }

        /// <summary>
        /// Draws an Icon from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Icon GetImageAsIcon(string SVGString)
        {
            var bitmap = Convert(SVGString);
            var icon = Icon.FromHandle(bitmap.GetHicon());

            return icon;
        }

        /// <summary>
        /// Draws a square Icon from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Icon GetImageAsIcon(string SVGString, int Size)
        {
            var bitmap = Convert(SVGString, Size, Size);
            var icon = Icon.FromHandle(bitmap.GetHicon());

            return icon;
        }

        /// <summary>
        /// Draws a sized Icon from an SVG Data XML string
        /// </summary>
        /// <param name="SVGString"></param>
        /// <returns></returns>
        internal static Icon GetImageAsIcon(string SVGString, int Height, int Width)
        {
            var bitmap = Convert(SVGString, Height, Width);
            var icon = Icon.FromHandle(bitmap.GetHicon());

            return icon;
        }

        #endregion
    }
}