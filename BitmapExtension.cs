using System;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HP.PC.Presentation;

namespace WpfCsSample
{
    public static class BitmapExtension
    {
        public static BitmapSource BitmapSourceFromStrokes(PcPhysicalSize physicalSize, PcPixelDensity pixelDensity, Vector imageScale, StrokeCollection strokes)
        {
            // removing transparency
            StrokeCollection cloneStrokes = strokes.Clone();
            foreach (var stroke in cloneStrokes)
            {
                var color = stroke.DrawingAttributes.Color;
                stroke.DrawingAttributes.Color = new Color { A = 255, R = color.R, G = color.G, B = color.B, };
            }

            const double mmToInches = 25.4;
            int pixelWidth = Convert.ToInt32(physicalSize.Width * pixelDensity.X);
            int pixelHeight = Convert.ToInt32(physicalSize.Height * pixelDensity.Y);

            double dpiX = mmToInches * pixelDensity.X;
            double dpiY = mmToInches * pixelDensity.Y;

            var dvInk = new DrawingVisual();
            using (DrawingContext ctxInk = dvInk.RenderOpen())
            {
                cloneStrokes.Draw(ctxInk);
            }
            dvInk.Transform = new ScaleTransform(1 / imageScale.X, 1 / imageScale.Y);

            // Render the bitmap into the same physical size as the original outline.
            var strokesBmp = new RenderTargetBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Default);

            // Place the stroke content into a bitmap.
            strokesBmp.Render(dvInk);

            return strokesBmp;
        }
    }
}
