using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double z = 0.0, y, x = 0, g;
            int a = 0;
            int caseSwitch = 0;
            bool mistake = false;
            while (true)
            {
                try
                {
                    Console.WriteLine("Input z(actual number): ");
                    z = Convert.ToDouble(Console.ReadLine());
                    mistake = false;
                }
                catch (Exception)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please, input digit:");
                }
                if (mistake == false)
                    break; 
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input a(actual number): ");
                    a = Convert.ToInt32(Console.ReadLine());
                    mistake = false;
                }
                catch (Exception)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please, input digit:");
                }
                if (mistake == false)
                    break;

            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Input number of case: ");
                    caseSwitch = Convert.ToInt32(Console.ReadLine());
                    mistake = false;
                }
                catch (Exception)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please, input digit:");
                }
                if (mistake == false)
                    break;
            }
            switch(caseSwitch)
            {
                case 1:
                    g = 2 * x;
                    break;
                case 2:
                    g = Math.Pow(x, 2);
                    break;
                case 3:
                    g = x / 3;
                    break;
                default:
                    g = Math.Sin(x);
                    break;
            }

            if (z < 1)
            {
                x = Math.Pow(z, 2);
            }
            else
            {
                x = z + 1;
            }

            y = a * Math.Log(1 + Math.Pow(x, 0.2)) + Math.Pow(Math.Cos(g + 1), 2);
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
}
