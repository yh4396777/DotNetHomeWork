using Microsoft.VisualStudio.TestTools.UnitTesting;
using 订单;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

namespace orderTestProject1
{
    [TestClass]
    [Serializable]
    public class order
    {
        public string myname = "yh";

        public List<orderdetails> details = new List<orderdetails>()
        {new orderdetails("001","Tom","21.2"),
        new orderdetails("002","plane","9.98"),
        new orderdetails("003","cup","3.4")};







    }
    public class orderdetails
    {
        public string ordernumber;
        public string buyname;

        public string cost;

        public orderdetails()
        { }
        public orderdetails(string v1, string v2, string v3)
        {
            this.ordernumber = v1;
            this.buyname = v2;
            this.cost = v3;
        }

        public override bool Equals(object obj)
        {
            orderdetails a = obj as orderdetails;
            return a != null && a.ordernumber == ordernumber && a.buyname == buyname && a.cost == cost;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(ordernumber);
        }
        public override string ToString()
        {

            return "订单号" + ordernumber + "商品名" + buyname + "金额" + cost;



        }






    }
    public class UnitTest1
    {
        [TestMethod]

        public void testque()
        {

            orderservice a = new orderservice();
            orderdetails b = new orderdetails("003", "cup", "3.4");
            orderdetails c = new orderdetails("002", "plane", "9.98");
            Console.WriteLine(a.Queue("001", 1));
            Console.WriteLine(a.Queue("001", 2));


            a.delete(b);
            a.modify(c, 1, "table");
            Console.WriteLine(a.Queue("002", 1));
            a.sort();
            a.Export();
        }
        public void testadd()
        {
            orderservice a = new orderservice();
            orderdetails b = new orderdetails("005", "gold", "9.9");
            a.Add(b);
            Console.WriteLine(a.Queue("005", 1));

        }
        public void testdelete()
        {
            orderservice a = new orderservice();
            orderdetails b = new orderdetails("005", "gold", "9.9");
            a.delete(b);
            Console.WriteLine(a.Queue("005", 1));

        }
        public void testmodify()
        {
            orderservice a = new orderservice();
            orderdetails c = new orderdetails("002", "plane", "9.98");
            a.modify(c, 1, "table");
            Console.WriteLine(a.Queue("002", 1));
        }
        public void testsort()
        {
            orderservice a = new orderservice();
            order b = new order();
            a.sort();
            foreach (var x in b.details)
            { Console.WriteLine(x); }


        }
        public void testxml()
        {
            orderservice a = new orderservice();
            a.Export();
            orderdetails b = new orderdetails("005", "gold", "9.9");
            a.Add(b);
            a.import();
            order c = new order();
            foreach (var x in c.details)
            { Console.WriteLine(c); }

        }

    }

    internal class orderservice
    {
        public void import()
        {
            order c = new order();
            XmlSerializer xmlserializer = new XmlSerializer(c.details.GetType());
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                c = (order)xmlserializer.Deserialize(fs);

            }

        }
        internal void Add(orderdetails a)
        {
            order c = new order();
            foreach (var x in c.details)
            {
                if (a.Equals(x))
                    return;
            }
            c.details.Add(a);
        }

        internal void delete(orderdetails a)
        {
            order c = new order();
            try
            { c.details.Remove(a); }
            catch (Exception)
            { Console.WriteLine("删除异常"); }
        }

        internal void Export()
        {
            order c = new order();
            XmlSerializer xmlserializer = new XmlSerializer(c.details.GetType());
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlserializer.Serialize(fs, c.details);
            }
        }

        internal void modify(orderdetails a, int b, string d)
        {

            order c = new order();
            try
            {
                switch (b)
                {
                    case 1:

                        foreach (var s in c.details)
                        {
                            if (s.ordernumber == a.ordernumber)
                                s.buyname = d;
                        }

                        break;


                    case 2:
                        foreach (var s in c.details)
                        {
                            if (s.ordernumber == a.ordernumber)
                                s.cost = d;
                        }

                        break;
                    default:
                        throw new Exception("修改项未包含");
                }
            }
            catch (Exception)
            { Console.WriteLine("修改失败"); }
        }

        internal string Queue(string a, int b)
        {
            order c = new order();
            switch (b)
            {
                case 1:
                    var query = from s in c.details
                                where s.ordernumber == a
                                select s.buyname;

                    foreach (var x in query)
                    {
                        return x;
                    }
                    return "未查询到";









                case 2:

                    var queryb = from s in c.details
                                 where s.ordernumber == a
                                 select s.cost;

                    foreach (var x in queryb)
                    {
                        return x;
                    }
                    return "未查询到";




                default:
                    return "请重新输入数字";

            }

        }

        internal void sort()
        {
            order c = new order();
            c.details.Sort((p1, p2) => Convert.ToInt32(p1.ordernumber) - Convert.ToInt32(p2.ordernumber));

        }
    }



}
