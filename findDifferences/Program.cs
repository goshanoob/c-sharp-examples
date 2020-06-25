using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp6
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Kartinka
    {
        Bitmap picture_one, picture_two;
        int num = 0;
        TimerCallback tm = new TimerCallback(Count);
        System.Threading.Timer timer;


        //= new System.Threading.Timer(tm, null, 0, 2000)

        public void makeClick()
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


        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 9; i++, x++)
            {
                Console.WriteLine("{0}", x * i);
            }
        }
    }




}
