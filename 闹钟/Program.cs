using System;

namespace 闹钟
{
    public class TimeChangeEventArgs : EventArgs

    {

       public DateTime a = DateTime.Now;

     public   DateTime b = DateTime.Now;

    

    }
    public delegate void timehandaler(TimeChangeEventArgs e);
    public class time
    {
        public event timehandaler tick;
        
        public void flock()
        {
            TimeChangeEventArgs e = new TimeChangeEventArgs();
            tick( e); 
        } 
    }
    public class clock
    { public time t1 = new time();
        public time t2 = new time();
        public clock()
            {
            t1.tick += new timehandaler(cltick);
            t2.tick += new timehandaler(clocktime);

    }

    public void cltick(TimeChangeEventArgs e)

        {if (e.a != e.b)
                Console.WriteLine("滴答");

            System.Threading.Thread.Sleep(1000);
        }
        public void clocktime(TimeChangeEventArgs e)
        {if(DateTime.Now.Second==9)
                Console.WriteLine("闹钟响了");

        }

    }
    

    class Program
    {
        static void Main(string[] args)
        {
            clock clock1 = new clock();
            TimeChangeEventArgs e=new TimeChangeEventArgs();
            while (true)
            {

                clock1.t1.flock();
                clock1.t2.flock();
            }
        }
    }
}
