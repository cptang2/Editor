using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Editor
{
    class ScaleBmp
    {
        public static void setImg(PictureBox StepPic, Bitmap bmp)
        {
            if ((StepPic.Width | StepPic.Height) == 0)
                return;

            Action set = () => 
            {
                if (StepPic.Image != null)
                    StepPic.Image.Dispose();

                StepPic.Image = ScaleBmp.Scale(bmp, StepPic.Width, StepPic.Height); 
            };

            StepPic.Invoke((Delegate) set);
        }

        //Scale a bitmap to the specified size
        private static Bitmap Scale(Bitmap bmp, int width, int height)
        {
            Bitmap img = new Bitmap(width, height);
            SolidBrush brush = new SolidBrush(Color.Black);

            using (Graphics grph = Graphics.FromImage(img))
            {
                grph.FillRectangle(brush, new RectangleF(0, 0, width, height));
                grph.InterpolationMode = InterpolationMode.High;
                grph.CompositingQuality = CompositingQuality.HighQuality;
                grph.SmoothingMode = SmoothingMode.AntiAlias;

                grph.DrawImage(bmp, new RectangleF(0, 0, width, height));
            };

            return img;
        }
    }
}
