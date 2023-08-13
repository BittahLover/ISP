using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WorkLibrary
{
    class Program
    {
        [DllImport("E:\\University\\isp\\labsc#\\4 laba\\secondTask\\Mydll\\Debug\\Mydll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int subtract(int a, int b);
        [DllImport("E:\\University\\isp\\labsc#\\4 laba\\secondTask\\Mydll\\Debug\\Mydll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int add(int a, int b);

        static void Main(string[] args)
        {
            int a = 0, b = 0, c = 0, d = 0, m = 0;
            Console.WriteLine("Input digits:");
            //bool alpha = true;
            while (true)
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Something goes wrong");
                    continue;
                }
                break;
            }
            while (true)
            {
                try
                {
                    b = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Something goes wrong");
                    continue;
                }
                break;
            }
            Console.WriteLine("Choose action:");
            Console.WriteLine("1. a - b");
            Console.WriteLine("2. a + b");
            while (true)
            {
                try
                {
                    m = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Something goes wrong");
                    continue;
                }
                break;
            }
            switch (m)
            {
                case 1:
                    c = subtract(a, b);
                    Console.WriteLine($"a - b = {c}");
                    break;
                case 2:
                    d = add(a, b);
                    Console.WriteLine($"a + b = {d}");
                    break;
            }
            Console.ReadKey();
        }
    }
}
