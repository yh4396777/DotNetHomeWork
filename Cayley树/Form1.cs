using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley树
{
    public partial class Form1 : Form
    {public Graphics graphics;
        public  void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            double th1 = Convert.ToDouble(textBox5.Text)
                 * Math.PI / 180;
            double th2 = Convert.ToDouble(textBox6.Text) * Math.PI / 180;
            double per1 = Convert.ToDouble(textBox3.Text);
            double per2 = Convert.ToDouble(textBox4.Text);

            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawline(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        public void drawline(double x0, double y0, double x1, double y1)
        {
            string a = (string)color.SelectedItem;
        if(a=="Black")

            graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
    else        if (a == "Blue")

                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
      else      if (a == "Silver")

                graphics.DrawLine(Pens.Silver, (int)x0, (int)y0, (int)x1, (int)y1);
    else        if (a == "Gray")

                graphics.DrawLine(Pens.Gray, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            DrawCayleyTree(Convert.ToInt32(textBox1.Text), 200, 310, Convert.ToDouble(textBox2.Text), -Math.PI / 2);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void color_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
