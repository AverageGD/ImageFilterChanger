

using System.Drawing;

namespace WindowsFormsApp1
{
    internal class InversionFilter : Filter
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

                    Color newColor = Color.FromArgb(255 - red, 255 - green, 255 - blue);

                    bitmap.SetPixel(j, i, newColor);
                }
            }

            return bitmap;
        }
    }
}
