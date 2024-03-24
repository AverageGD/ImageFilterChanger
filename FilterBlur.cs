using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    internal class DreamcoreFilter : Filter
    {
        public override Bitmap UseFilter(Image defaultImage)
        {
            Bitmap bitmap = new Bitmap(defaultImage);

            for (int i = 10; i < defaultImage.Height - 10; i++)
            {
                for (int j = 0; j < defaultImage.Width; j++)
                {
                    int R = 0, G = 0, B = 0;

                    for (int k = -2; k <= 2; k++)
                    {
                        R += bitmap.GetPixel(i - k, j).R;
                        G += bitmap.GetPixel(i - k, j).G;
                        B += bitmap.GetPixel(i - k, j).B;
                    }
                    byte bR = (byte)(R / 3);
                    byte bG = (byte)(G / 3);
                    byte bB = (byte)(B / 3);


                    Color cBlured = Color.FromArgb(bR, bG, bB);

                    bitmap.SetPixel(i, j, cBlured);

                }
            }

            return bitmap;
        }
    }
}
