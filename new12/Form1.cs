using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string[] b = new string[10];


            b[0] = textBox1.Text;
            b[1] = "+";
            b[2] = textBox2.Text;
            int a = Convert.ToInt32(b[0]);
            int c = Convert.ToInt32(b[2]);
            int d;
            switch (b[1])
            {
                case "+":
                    d = a + c;
                   textBox3.Text=Convert.ToString(d);
                    break;
                case "-":
                    d = a - c;
                    textBox3.Text = Convert.ToString(d);
                    break;

                case "*":
                    d = a * c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "/":
                    d = a / c;
                    textBox3.Text = Convert.ToString(d);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] b = new string[10];


            b[0] = textBox1.Text;
            b[1] = "-";
            b[2] = textBox2.Text;
            int a = Convert.ToInt32(b[0]);
            int c = Convert.ToInt32(b[2]);
            int d;
            switch (b[1])
            {
                case "+":
                    d = a + c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "-":
                    d = a - c;
                    textBox3.Text = Convert.ToString(d);
                    break;

                case "*":
                    d = a * c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "/":
                    d = a / c;
                    textBox3.Text = Convert.ToString(d);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] b = new string[10];


            b[0] = textBox1.Text;
            b[1] = "*";
            b[2] = textBox2.Text;
            int a = Convert.ToInt32(b[0]);
            int c = Convert.ToInt32(b[2]);
            int d;
            switch (b[1])
            {
                case "+":
                    d = a + c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "-":
                    d = a - c;
                    textBox3.Text = Convert.ToString(d);
                    break;

                case "*":
                    d = a * c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "/":
                    d = a / c;
                    textBox3.Text = Convert.ToString(d);
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] b = new string[10];


            b[0] = textBox1.Text;
            b[1] = "/";
            b[2] = textBox2.Text;
            int a = Convert.ToInt32(b[0]);
            int c = Convert.ToInt32(b[2]);
            int d;
            switch (b[1])
            {
                case "+":
                    d = a + c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "-":
                    d = a - c;
                    textBox3.Text = Convert.ToString(d);
                    break;

                case "*":
                    d = a * c;
                    textBox3.Text = Convert.ToString(d);
                    break;
                case "/":
                    d = a / c;
                    textBox3.Text = Convert.ToString(d);
                    break;
            }
        }
    }
}
