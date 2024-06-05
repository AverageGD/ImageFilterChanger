using System.Drawing;

namespace WindowsFormsApp1
{
    internal abstract class Filter : IFeature
    {
        public Bitmap ImplementFeature(MyDelegate del, Image img)
        {
            return del(img);
        }

        public abstract Bitmap UseFilter(Image defaultImage);
    }
}
