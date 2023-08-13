using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secondLab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0, m = 0;
            string s = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
            string s1 = DateTime.Now.ToString("R");
            Console.WriteLine(s);
            Console.WriteLine(s1);
            StringBuilder sb = new StringBuilder(s);
            for(int i = 0;  i < sb.Length; i++)
            {
                if (sb[i] == '1')
                    a++;
                if (sb[i] == '2')
                    b++;
                if (sb[i] == '3')
                    c++;
                if (sb[i] == '4')
                    d++;
                if (sb[i] == '5')
                    e++;
                if (sb[i] == '6')
                    f++;
                if (sb[i] == '7')
                    g++;
                if (sb[i] == '8')
                    h++;
                if (sb[i] == '9')
                    m++; 
            }
            StringBuilder sc = new StringBuilder(s1);
            for (int l = 0; l < sc.Length; l++)
            {
                if (sc[l] == '1')
                    a++;
                if (sc[l] == '2')
                    b++;
                if (sc[l] == '3')
                    c++;
                if (sc[l] == '4')
                    d++;
                if (sc[l] == '5')
                    e++;
                if (sc[l] == '6')
                    f++;
                if (sc[l] == '7')
                    g++;
                if (sc[l] == '8')
                    h++;
                if (sc[l] == '9')
                    m++;
            }

            Console.WriteLine("\nCount of 1 -- {0}", a);
            Console.WriteLine("Count of 2 -- {0}", b);
            Console.WriteLine("Count of 3 -- {0}", c);
            Console.WriteLine("Count of 4 -- {0}", d);
            Console.WriteLine("Count of 5 -- {0}", e);
            Console.WriteLine("Count of 6 -- {0}", f);
            Console.WriteLine("Count of 7 -- {0}", g);
            Console.WriteLine("Count of 8 -- {0}", h);
            Console.WriteLine("Count of 9 -- {0}\n", m);


        }
    }
}
