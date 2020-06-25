using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Threading;



namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        public List<int> pointsX = new List<int>();
        public List<int> pointsY = new List<int>();
        System.Timers.Timer t = new System.Timers.Timer();
        
        bool str = true;

        private void button1_Click(object sender, EventArgs e)

           
        {
            drawing();
            /*
            int x1, y1, h1, w1, x2, y2, h2, w2;
            x1 = 758;
            y1 = 263;
            x2 = 1100;
            y2 = 263;
            h1 = 748-y1;
            w1 = 1088-x1;
            h2 = h1;
            w2 = w1;

             Bitmap img_left = new Bitmap(w1, h1);
             Bitmap img_right = new Bitmap(w1, h1);

            
             Graphics g = Graphics.FromImage(scr);
             g.CopyFromScreen(x1, y1, 0, 0, new Size(w1,h1));
             scr.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/one.jpg", ImageFormat.Jpeg);
             g.CopyFromScreen(x2, y2, 0, 0, new Size(w2, h2));
             scr.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/two.jpg", ImageFormat.Jpeg);
            
            Graphics g_left = Graphics.FromImage(img_left);
            g_left.CopyFromScreen(x1, y1, 0, 0, new Size(w1, h1));

            Graphics g_right = Graphics.FromImage(img_right);
            g_right.CopyFromScreen(x2, y2, 0, 0, new Size(w2, h2));

            
            for (int i = 0; i < img_left.Width; i++)
            {
                for (int j = 0; j < img_left.Height; j++)
                {
                    if (img_left.GetPixel(i, j) != img_right.GetPixel(i, j))
                    {
                        pointsX.Add(i+ x1);
                        pointsY.Add(j+y1);
                    }
                }

            }

            saver();
            */

        }


        public void drawing()
        {
            for (int i = 0; i < pointsX.Count; i++)
            {
                Cursor.Position = new Point(pointsX[i], pointsY[i]);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);//make left button down
                //System.Threading.Thread.Sleep(2000);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//make left button up
                System.Threading.Thread.Sleep(500);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            pointsX.Clear();
            pointsY.Clear();
            t.Enabled = false;
            saver();
        }





        public void saver()
        {
            
            int x1, y1, h1, w1, x2, y2, h2, w2;
            x1 = 758;
            y1 = 263;
            x2 = 1100;
            y2 = 263;
            h1 = 748 - y1;
            w1 = 1088 - x1;
            h2 = h1;
            w2 = w1;

            Bitmap scr1 = new Bitmap(w1, h1);
            Bitmap scr2 = new Bitmap(w2, h2);


            Graphics g = Graphics.FromImage(scr1);
            g.CopyFromScreen(x1, y1, 0, 0, new Size(w1, h1));
            scr1.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/one.jpg", ImageFormat.Jpeg);

            g = Graphics.FromImage(scr2);
            g.CopyFromScreen(x2, y2, 0, 0, new Size(w2, h2));
            scr2.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/two.jpg", ImageFormat.Jpeg);

            pictureBox1.Height = h1;
            pictureBox1.Width = w1;
            // -200; -20


            //System.Threading.Timer t = new System.Threading.Timer(tick, null, 0, 500);
            //  pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;


            t.Interval = 200;
            t.Elapsed += (o, e) => tick(scr1, scr2);
            t.AutoReset = true;

            t.Enabled = true;
           
            
            //t.Start();
            


        }
        
        public void tick(Bitmap scr1, Bitmap scr2)
        {

            

            if (str)
            {
                pictureBox1.BackgroundImage = scr1;
            } else
            {
                pictureBox1.BackgroundImage = scr2;
            }
            /*
            for (int i = 0; i < pointsX.Count; i++)
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawEllipse(new Pen(Brushes.Red), pointsX[i] - 758, pointsY[i] - 263, 30, 30);
            }
            */
            str = !str;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getChoose();
        }

        public void getChoose()
        {
            List<bool> iHash1 = GetHash(new Bitmap(@"C:\Users\goshanoob\Desktop\one.jpg"));
            
            List<bool> iHash2 = GetHash(new Bitmap(@"C:\Users\goshanoob\Desktop\two.jpg"));

            //determine the number of equal pixel (x of 256)
            int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);
            MessageBox.Show("f");
        }

            public  List<bool> GetHash(Bitmap bmpSource)
            {
                List<bool> lResult = new List<bool>();
                //create new image with 16x16 pixel
                Bitmap bmpMin = new Bitmap(bmpSource, new Size(330, 485));
                for (int j = 0; j < bmpMin.Height; j++)
                {
                    for (int i = 0; i < bmpMin.Width; i++)
                    {
                        //reduce colors to true / false                
                        if(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f)
                    {
                        pointsX.Add(i + 758);
                        pointsY.Add(j + 263);
                    }
                    
                }
                }
                return lResult;
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            int x = this.PointToClient(Cursor.Position).X;
            int y = this.PointToClient(Cursor.Position).Y;
            pointsX.Add(758+x-130);
            pointsY.Add(263+y-20);

            


        }
    }
}
