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
using static 订单窗体.Form1;

namespace 订单窗体
{
    public partial class Form2 : Form
    {
        public  Form1.orderdetails orderdetails;
        public Form1.order order;
        public Form1.orderservice orderservice;
        
      
         

      
        
        public Form2()
        {
            InitializeComponent();
        }
     
      
        private void textBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void modifytext(string buyname,string cost)
        {
            orderdetails a = new orderdetails();
           
            a.ordernumber = textBox4.Text;
         
            a.buyname = b.Queue(a.ordernumber, 1);
            a.cost = b.Queue(a.ordernumber, 2);


    
            
            b.modify(a, 1, buyname);
            b.modify(a, 2, cost);
        }
      

       

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
            orderdetails a = new orderdetails();
            a.buyname = textBox2.Text;
            a.cost = textBox3.Text;
            a.ordernumber = textBox4.Text;
            bool d = b.Judge(a);
            if (d)
                b.delete(a);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
           

        }
        public orderservice b = new orderservice();
        private void button2_Click_1(object sender, EventArgs e)
        {

            
           
          
            orderdetails f = new orderdetails();
            f.ordernumber = textBox4.Text;
            textBox1.Text = Convert.ToString("yh");

            string c = b.Queue(Convert.ToString(f.ordernumber), 1);
            textBox2.Text = c;
            string d = b.Queue(Convert.ToString(f.ordernumber), 2);
            textBox3.Text = d;

            
      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            orderdetails a = new orderdetails(); 
            a.ordernumber = textBox4.Text;
            a.buyname = b.Queue(a.ordernumber, 1);
            a.cost = b.Queue(a.ordernumber, 2);
            orderdetails c = new orderdetails("004", "prdie", "5.35");
            b.Add(c);
            
            bool d = b.Judge(a);
            if (d)
            {
              
                modifytext(textBox2.Text, textBox3.Text);
            }
                
            else
            {
               a.buyname = textBox2.Text;
                a.cost = textBox3.Text;
                b.Add(a);

            }

        }
    }
}
