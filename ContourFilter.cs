

using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class ContourFilter : Filter
    {
        public override Bitmap UseFilter(Image defaultImage)
        {
            Bitmap bitmap = new Bitmap(defaultImage);

            for (int i = 0; i < defaultImage.Height; i++)
            {
                for (int j = 0; j < defaultImage.Width; j++)
                {
                    short red = bitmap.GetPixel(j, i).R;
                    short green = bitmap.GetPixel(j, i).G;
                    short blue = bitmap.GetPixel(j, i).B;

                    Color newColor = Color.FromArgb((red + green + blue) / 3, (red + green + blue) / 3, (red + green + blue) / 3);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            for (int i = 0; i < defaultImage.Height - 1; i++)
            {
                for (int j = 0; j < defaultImage.Width - 1; j++)
                {
                    int current = bitmap.GetPixel(j, i).G;
                    int up = bitmap.GetPixel(j, i + 1).G;
                    int right = bitmap.GetPixel(j + 1, i).G;

                    int dx = Math.Abs(current - up);
                    int dy = Math.Abs(current - right);

                    int gradient = (int)Math.Sqrt(dx * dx + dy * dy) * 100;

                    gradient = Math.Min(255, gradient);

                    Color newColor = Color.FromArgb(gradient, gradient, gradient);

                    bitmap.SetPixel(j, i, newColor);

                }
            }

            return bitmap;
        }
    }
}
