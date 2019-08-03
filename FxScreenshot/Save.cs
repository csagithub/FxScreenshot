using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FxScreenshot
{
    public class Capture
    {
        public static void Desktop(string strPath)

        {
            //Creating a new Bitmap object

            Bitmap captureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);

            //Creating a Rectangle object which will  

            //capture our Current Screen

            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

            //Creating a New Graphics Object

            Graphics captureGraphics = Graphics.FromImage(captureBitmap);

            //Copying Image from The Screen

            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

            //Saving the Image File (I am here Saving it in My E drive).

            captureBitmap.Save(strPath, ImageFormat.Jpeg);

            //Displaying the Successfull Result
        }

    }
}
