using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
   
    class Program
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        static void Main(string[] args)
        {
            //Graphics.FromHwnd(IntPtr.Zero);
            
            IntPtr desktop = GetDC(IntPtr.Zero);
            Console.WriteLine("SiMpLe PAINting");
            A:
                Console.WriteLine("\n1 - Rectangle");
                Console.WriteLine("2 - Ellipse");
                Console.WriteLine("3 - twoFigures");
                Console.WriteLine("4 - Exit");
            int a = 0;
            while (true)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Wrong input 0_0");
                    continue;
                }
                break;
            }
          
            switch (a)
                {
                    case 1:
                        using (Graphics g = Graphics.FromHdc(desktop))
                        {
                            g.FillRectangle(brush: Brushes.Yellow, x: 600, y: 700, width: 400, height: 500);
                        }
                        goto A;
                       
                    case 2:
                        using (Graphics g = Graphics.FromHdc(desktop))
                        {
                            g.FillEllipse(brush: Brushes.MediumVioletRed, x: 300, y: 700, width: 400, height: 500);
                        }
                        goto A;
                    case 3:
                        using (Graphics g = Graphics.FromHdc(desktop))
                        {
                            g.FillRectangle(brush: Brushes.OliveDrab, x: 900, y: 500, width: 400, height: 500);
                        }
                        using (Graphics g = Graphics.FromHdc(desktop))
                        {
                            g.FillEllipse(brush: Brushes.Azure, x: 300, y: 500, width: 400, height: 500);
                        }
                        goto A;
                    case 4:
                    {
                        break;
                    }
                    default:
                        Console.WriteLine("You entered wrong number");
                    goto A;
                }  
        }
    }
}
