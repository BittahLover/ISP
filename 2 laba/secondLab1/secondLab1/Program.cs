using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace secondLab1
{
    class Program
    {

        static void Main(string[] args)
        {
            int monthLanguage = 8;
            Console.WriteLine("choose the language: ");
            Console.WriteLine("0 - Русский язык");
            Console.WriteLine("1 - English Language");
            Console.WriteLine("2 - Le français");
            Console.WriteLine("3 - Беларуская мова");
            Console.WriteLine("4 - Čeština");
            Console.WriteLine("5 - Polski język");
            Console.WriteLine("6 - -Exit-");
            bool mistake = false;
            while (true)
            {
                try
                {
                    Console.WriteLine("choose the language: ");
                    monthLanguage = Convert.ToInt32(Console.ReadLine());
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
            switch (monthLanguage)
            {
                case 0:
                    string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                    foreach (string m in monthNames)
                    {
                        Console.WriteLine(m);
                    }
                    break;

                case 1:
                    string[] monthNames1 = (new System.Globalization.CultureInfo("en-US")).DateTimeFormat.MonthNames;

                    foreach (string m in monthNames1)
                    {
                        Console.WriteLine(m);
                    }

                    break;

                case 2:
                    string[] monthNames2 = (new System.Globalization.CultureInfo("fr-CA")).DateTimeFormat.MonthNames;

                    foreach (string m in monthNames2)
                    {
                        Console.WriteLine(m);
                    }

                    break;

                case 3:
                    string[] monthNames4 = (new System.Globalization.CultureInfo("be-BY")).DateTimeFormat.MonthNames;

                    foreach (string m in monthNames4)
                    {
                        Console.WriteLine(m);
                    }
                    break;

                case 4:
                    string[] monthNames5 = (new System.Globalization.CultureInfo("cs-CZ")).DateTimeFormat.MonthNames;

                    foreach (string m in monthNames5)
                    {
                        Console.WriteLine(m);
                    }
                    break;
                case 5:
                    string[] monthNames6 = (new System.Globalization.CultureInfo("pl-PL")).DateTimeFormat.MonthNames;

                    foreach (string m in monthNames6)
                    {
                        Console.WriteLine(m);
                    }
                    break;
                case 6:
                    Environment.Exit(0);
                    break; 

            }
        }
    }
}

