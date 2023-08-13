using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool mistake = false;
            bool mistake1 = true;
            double e = 0.0, f = 0.0, c = 0.0;
            Console.WriteLine("Треугольник ABC");
            while (true)
            {
                try
                {
                    
                    mistake = true;
                    while (mistake1)
                    {
                        Console.WriteLine("Введите угл a: ");
                        e = Convert.ToDouble(Console.ReadLine()); // 1 угол
                        if (e > 180) Console.WriteLine("Retry");
                        else
                        {
                            mistake1 = false;
                            mistake = false;
                        }
                    }
                }

                catch(FormatException)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please repeat ");
                }
                if (mistake == false)
                    break;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите угл b: ");
                    f = Convert.ToDouble(Console.ReadLine()); // 2 угол
                    mistake = false;
                }
                catch (FormatException)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please repeat ");
                }
                if (mistake == false)
                    break;
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите угл c: ");
                    c = Convert.ToDouble(Console.ReadLine()); // 2 угол
                    mistake = false;
                }
                catch (FormatException)
                {
                    mistake = true;
                    Console.WriteLine("Wrong input, please repeat ");
                }
                if (mistake == false)
                    break;
            }
            double g = 180 - e - f; //3 угол
            double a = c * Math.Sin(e / 57.2958) / Math.Sin(g / 57.2958); //сторона а 
            double b = a * Math.Sin(f/ 57.2958) / Math.Sin(e / 57.2958); //сторона b
            double P = a + b + c; // Периметр
            double p = P / 2; // Полупериметр
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Площадь
            double Ha = 2 * S / a; // Высота по стороне a
            double Hb = 2 * S / b; // Высота по стороне b
            double Hc = 2 * S / c; // Высота по стороне c
            double Ma = Math.Sqrt(2 * Math.Pow(b, 2) + 2 * Math.Pow(c, 2) - Math.Pow(a, 2)) / 2; // Медиана на сторону a 
            double Mb = Math.Sqrt(2 * Math.Pow(a, 2) + 2 * Math.Pow(c, 2) - Math.Pow(b, 2)) / 2; // Медиана на сторону b
            double Mc = Math.Sqrt(2 * Math.Pow(a, 2) + 2 * Math.Pow(b, 2) - Math.Pow(c, 2)) / 2; // Медиана на сторону c
            double La = Math.Sqrt(b * c * (a + b + c) * (b + c - a)) / (b + c); // Биссектриса на сторону a
            double Lb = Math.Sqrt(a * c * (a + b + c) * (a + c - b)) / (a + c); // Биссектриса на сторону b
            double Lc = Math.Sqrt(b * a * (a + b + c) * (a + b - c)) / (a + b); // Биссектриса на сторону c
            double r = Math.Sqrt((p - a) * (p - b) * (p - c) / p); // Окружность вписанная в треугольник
            double R = (a * b * c) / 4 * Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Окружность описанная около треугольника
            double i1 = 360 - e; // внешний угол а
            double l1 = 360 - f; // внешний угол b
            double g1 = 360 - g; // внешний угол с
            Console.WriteLine($"Угол g: {g}\nСторона a: {a}\nСторона b: {b}\nПериметр: {P}\nПлощадь: {P}\nВысота к стороне a: {Ha}\nВысота к стороне b: {Hb}\nВысота к стороне c: {Hc}\nМедиана к стороне а: {Ma}\nМедиана к стороне b: {Mb}\nМедиана к стороне с: {Mc}\nБиссектриса к стороне а: {La}\nБиссектриса к стороне b: {Lb}\nБиссектриса к стороне с: {Lc}\nОкружность вписанная в треугольник: {r}\nОкружность описанная около треугольника: {R}\nВнешний угол а: {i1}\nВнешний угол b: {l1}\nВнешний угол с: {g1}");

        }
    }
}
