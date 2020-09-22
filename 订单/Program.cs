using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using System.Text.Unicode;

namespace 订单
{
    [Serializable]
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
            return a!=null && a.ordernumber==ordernumber && a.buyname==buyname&&a.cost==cost;
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(ordernumber);
        }
        public override string ToString()
        {
            
               return   "订单号" + ordernumber + "商品名" + buyname + "金额" + cost;
               
           

        }
    }
  
    [Serializable]public  class order
    {
        public string myname="yh";
       
        public List<orderdetails> details = new List<orderdetails>()
        {new orderdetails("001","Tom","21.2"),
        new orderdetails("002","plane","9.98"),
        new orderdetails("003","cup","3.4")};
        


       



    }
 public class orderservice
    {
        order c = new order();


        public void Export()
        {
            XmlSerializer xmlserializer = new XmlSerializer(c.details.GetType());
        using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlserializer.Serialize(fs, c.details); 
            }
                    }
        public void import()
        {
            XmlSerializer xmlserializer = new XmlSerializer(c.details.GetType());
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                c = (order)xmlserializer.Deserialize(fs);

            }
        
        }
        public void sort()
        {

            c.details.Sort((p1, p2) => Convert.ToInt32(p1.ordernumber) - Convert.ToInt32(p2.ordernumber));
            
            
        }
        public void Add(orderdetails a)
        {foreach (var x in c.details)
            { if (a.Equals(x)) 
                return;
            }
            c.details.Add(a);
        }
        public void delete(orderdetails a)
        {try
            { c.details.Remove(a); }
            catch (Exception)
            { Console.WriteLine("删除异常"); }
        }
        public void modify(orderdetails a,int b,string d)
        {try
            {
                switch (b)
                {
                    case 1:

                        foreach (var s in c.details)
                        { if (s.ordernumber == a.ordernumber)
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
        public string Queue(string a, int b)
        {
           
            switch (b)
            { case 1:
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

        
    }
    class Program
    { 
            static void Main(string[] args)
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
    }
}
