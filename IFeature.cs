using System.Drawing;

namespace WindowsFormsApp1
{
    public delegate Bitmap MyDelegate(Image img);
    internal interface IFeature
    {
        Bitmap ImplementFeature(MyDelegate del, Image img);
    }
}
