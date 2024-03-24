using System.Drawing;

namespace WindowsFormsApp1
{
    internal abstract class Filter
    {
        public abstract Bitmap UseFilter(Image defaultImage);
    }
}
