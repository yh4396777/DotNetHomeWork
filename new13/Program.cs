using System;

namespace new13
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = Convert.ToInt32(Console.ReadLine());
            zhishu(a);
           
        }
        private static void zhishu(int a)
        {
            int[] b = new int[100];
            int c = 0;
            int g = 0;
            int h = 0;
            int[] d = new int[100];
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    b[c] = i;
                    c++;
                }
            }


            for (int i = 0; i < c + 1; i++)
            {

                for (int f = 2; f < b[i]; f++)
                {


                    if (b[i] % f == 0)
                        h++;
                }


                if (h == 0)
                {
                    d[g] = b[i];
                    g++;
                }


            }

            for (int i = 0; i < g + 1; i++)
            {
                if (d[i] != 0)
                    Console.WriteLine(d[i]);

            }
        }
    }
}
