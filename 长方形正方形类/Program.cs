using System;

namespace 长方形正方形类
{
    class Program
    {
        class cfx
        {
            public int x;
            public int y;
            public int s;
            public void caculation()
            {
                this.s = this.x * this.y;
               
            }
            public void cfxs()
            {
                Console.WriteLine("请输入长方形长和宽");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                cfx p = new cfx();
                p.x = x;
                p.y = y;
                p.caculation();
                Console.WriteLine("面积为{0}", Convert.ToString(p.s));
            }
        }
            class zfx
            {
                public int x;
                public int y;
                public int s;
            public void caculation()
            {
                this.s = this.x * this.y;
               }
                public bool judge()
            { if (x==y)
                    return true;
                else
                    return false;
            }
            public void zfxs()
            {
                Console.WriteLine("请输入正方形长和宽");
                int d = Convert.ToInt32(Console.ReadLine());
                int f = Convert.ToInt32(Console.ReadLine());

                zfx m = new zfx();
                m.x = d;
                m.y = f;
                bool h = m.judge();
                if (h)
                {
                    m.caculation();
                    Console.WriteLine("面积为{0}", Convert.ToString(m.s));
                }
                else
                {
                    Console.WriteLine("这不是个正方形");
                    zfxs();
                }
            }
        }
        class sjx
        {
            public double a;
            public double b;
            public double c;
            public double p;
            public double s;
            public double m;
            public double[] length = new double [3];
           
            public void caculation()
            {
                this.p = (a + b + c) / 2;
                this.s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
               
            }
            public bool judge()
            {
             
                if (a + b > c && a + c > b && b + c > a)
                    return true;
                else
                    return false;
            
            }
            
                public void sjxs()
                {
                    Console.WriteLine("请输入三角形三边长");
                    sjx k = new sjx();
                    double a = Convert.ToDouble(Console.ReadLine());
                
                    double b = Convert.ToDouble(Console.ReadLine());
                    double c = Convert.ToDouble(Console.ReadLine());
                k.a = a;
                k.b = b;
                k.c = c;
                    bool h = k.judge();
                    if (h)
                    {
                        k.caculation();
                        Console.WriteLine("面积为{0}", Convert.ToString(Convert.ToInt32(k.s)));

                    }
                    else
                    {
                        Console.WriteLine("这构不成三角形");
                        sjxs();
                    }
                }
            
        }
       
        



        static void Main(string[] args)
                {
            cfx a = new cfx();
            zfx b = new zfx();
            sjx c = new sjx();
            a.cfxs();
            b.zfxs();
            c.sjxs();
            
              
           
        }

            
        }
    }

