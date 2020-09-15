using System;

namespace 长方形正方形类
{
    class Program
    {
        
        

        class Factory
        {
            //静态工厂方法  
            
            public static int getProduct(String arg)
            {

                if (arg == "A" )
                {
                    ConcreteProductA a = new ConcreteProductA();
                    a.make();
                    a.caculation();
                    return a.s;

                }
                else if (arg == "B" )
                {
                    ConcreteProductB a = new ConcreteProductB();
                    a.make();
                    a.caculation();
                    return a.s;

                }
                else if (arg == "C" )
                {
                    ConcreteProductC a = new ConcreteProductC();
                    a.make();
                    a.caculation();
                    return a.s;

                }
                else
                { Console.WriteLine("请重新输入");
                    Factory.getProduct(Console.ReadLine());
                    return 0;


                }    
                
            }
        }
        class Product
        {
            
            
        }
        class ConcreteProductA : Product
        {
            public int x;
            public int y;
            public int s;
            public void caculation()
            {
                this.s = this.x * this.y;

            }
            public void make()
            {
                Random ran = new Random();
                this.x = ran.Next(1, 10);
                this.y = ran.Next(1, 10);
            } }
        class ConcreteProductB:Product
        {
            public int x;
            public int y;
            public int s;
            public void caculation()
            {
                this.s = this.x * this.y;
            }
            public void make()
            {
                Random ran = new Random();
                this.x = ran.Next(1, 10);
                this.y = this.x;
            }
        }
        class ConcreteProductC:Product
        {
            public double a;
            public double b;
            public double c;
            public double p;
            public int s;
            public double m;
            public double[] length = new double[3];

            public void caculation()
            {
                if (a + b > c && a + c > b && b + c > a)
                {
                    this.p = (a + b + c) / 2;
                    this.s = Convert.ToInt32(Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
                        
                }
                else
                { make();
                    caculation();
                }

            }
            public void make()
            {
                Random ran = new Random();
                this.a = ran.Next(1, 10);
                this.b = ran.Next(1, 10);
                this.c= ran.Next(1, 10);
               
            }
        }
        public static int init()
        {
           int a = Factory.getProduct(Console.ReadLine());
            return a;
        }
       
    

    static void Main(string[] args)
        {
            int a = 0;
            for (int i = 0; i < 10; i++)
            {
                a=a+init();

            }

            Console.WriteLine("总面积为{0}",a);
        }


    }
}

