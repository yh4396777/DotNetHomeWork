using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;


namespace intelbugwinform
{
    public partial class Form1 : Form
    {
        
      
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
                a[i] = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
               Crawler.startUrl = textBox1.Text;

                Crawler.begin();
                Parallel.Invoke(new Action[]
                {
                    ()=>list(1),
                    ()=>list(2)});
               
                
            }
         

        }
        public void list(int index)
        {switch(index)
            { 
                case 1:
                    foreach (var x in a)
                    {
                        if (x != null)
                            richTextBox1.Text += "\n" + x;
                    }
                    break;

                    case 2:
                    foreach (var x in b)
                    {
                        if (x != null)
                            richTextBox2.Text += "\n" + x;
                    }
                    break;


        }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static string[] a = new string[10];
        public static string[] b = new string[10];



        public class Crawler

        { private static int count = 0;
           
            
          public static string startUrl;
            public Hashtable urls = new Hashtable();


            public static void begin()

            {
                Crawler myCrawler = new Crawler();





                myCrawler.urls.Add(startUrl, false);


                new Thread(myCrawler.Crawl).Start();

            }

            public bool judgehtml(string url)
            {

                return Regex.IsMatch(url, "html");
            }
            public bool judgehtm(string url)
            {

                return Regex.IsMatch(url, "htm");
            }
            public bool judgejsp(string url)
            {

                return Regex.IsMatch(url, "jsp");
            }
            public bool judgeaspx(string url)
            {

                return Regex.IsMatch(url, "aspx");
            }
            public bool judgephp(string url)
            {

                return Regex.IsMatch(url, "php");
            }
            private void Crawl()

            {

               
                while (true)

                {
                    string current = null;
                   
                        foreach (string url in urls.Keys)

                        {   //找到一个还没有下载过的链接

                            if ((bool)urls[url]) continue;
                            current = url;
                        }

                        //已经下载过的,不再下载

                        if (current == null || count > 10) break;


                        string s = ("爬行" + current + "页面!");

                        if (count < 10)
                            a[count] = s;
                    try
                    {
                        string html = DownLoad(current);
                        urls[current] = true;
                        count++;
                        if (judgehtml(html) || judgehtm(current) || judgejsp(current) || judgeaspx(current) || judgephp(current))
                            Parse(html);
                    }
                    catch
                    {
                        string c = ("爬行" + current + "异常!");
                        if (count < 10)
                            b[count] = c;
                    }
                }

                //解析,并加入新的链接





                Console.WriteLine("end");
            }

            public string DownLoad(string url)
            {

                try
                {

                    WebClient webClient = new WebClient();

                    webClient.Encoding = Encoding.UTF8;

                    string html = webClient.DownloadString(url);


                    string fileName = count.ToString();

                    File.WriteAllText(fileName, html, Encoding.UTF8); return html;
                }

                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); return "";
                }
            }

            public void Parse(string html)
            {

                string strRef = @"http://[^\s]*/""";
                MatchCollection matches = new Regex(strRef).Matches(html);


                foreach (Match match in matches)

                {

                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
            

                    if (strRef.Length == 0) continue;


                    if (urls[strRef] == null) urls[strRef] = false;
                

                }
            }
        }

    }



}



