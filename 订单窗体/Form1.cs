using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace 订单窗体
{
    public partial class Form1 : Form
    {
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
           
        }

        [Serializable]
        public class order
        {
            public string myname = "yh";

            public List<orderdetails> details = new List<orderdetails>()
        {new orderdetails("001","Tom","21.2"),
        new orderdetails("002","plane","9.98"),
        new orderdetails("003","cup","3.4")};




       


        }
       
            public static List<orderdetails> details = new List<orderdetails>()
        {new orderdetails("001","Tom","21.2"),
        new orderdetails("002","plane","9.98"),
        new orderdetails("003","cup","3.4")};
        public class orderservice
        {
            order c = new order();
           

            public void Export()
            {
                XmlSerializer xmlserializer = new XmlSerializer(details.GetType());
                using (FileStream fs = new FileStream("s.xml", FileMode.Create))
                {
                    xmlserializer.Serialize(fs, details);
                }
            }
            public void import()
            {
                XmlSerializer xmlserializer = new XmlSerializer(details.GetType());
                using (FileStream fs = new FileStream("s.xml", FileMode.Open))
                {
                    c = (order)xmlserializer.Deserialize(fs);

                }

            }
            public void sort()
            {

                details.Sort((p1, p2) => Convert.ToInt32(p1.ordernumber) - Convert.ToInt32(p2.ordernumber));


            }
            public void Add(orderdetails a)
            {
               
                details.Add(a);
            }
            public bool Judge(orderdetails a)
            {
                foreach (var x in details)
                {
                    if (a.Equals(x))
                        return true;
                }
                return false;
            }
            public void delete(orderdetails a)
            {
                try
                { details.Remove(a); }
                catch (Exception)
                { Console.WriteLine("删除异常"); }
            }
            public void modify(orderdetails a, int b, string d)
            {
                try
                {
                    switch (b)
                    {
                        case 1:

                            foreach (var s in details)
                            {
                                if (s.ordernumber == a.ordernumber)
                                    s.buyname = d;
                            }

                            break;


                        case 2:
                            foreach (var s in details)
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
                {
                    case 1:
                        var query = from s in details
                                    where s.ordernumber == a
                                    select s.buyname;

                        foreach (var x in query)
                        {
                            return x;
                        }
                        return "未查询到";









                    case 2:

                        var queryb = from s in details
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
            public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            order a = new order();
            orderservice b = new orderservice();
            orderdetails f =new orderdetails();
            f.ordernumber = textBox2.Text;
            textBox1.Text = Convert.ToString(a.myname);
            
           string c= b.Queue(Convert.ToString(f.ordernumber),1);
            textBox3.Text = c;
            string d = b.Queue(Convert.ToString(f.ordernumber), 2);
            textBox4.Text = d;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            new Form2().Show();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            new Form2().Show();
         
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            new Form2().Show();
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            orderservice a = new orderservice();
            a.Export();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            orderservice a = new orderservice();
            a.import();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
