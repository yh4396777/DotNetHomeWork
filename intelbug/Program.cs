


using System;



using System.Collections.Generic;

using System.Text;



using System.IO;



using System.Net;


using System.Collections;



using System.Text.RegularExpressions;
using System.Threading;


public class Crawler

{

    private Hashtable urls = new Hashtable();
    private int count = 0;
    public static string startUrl = "http://www.cnblogs.com/";

    static void Main(string[] args)

    {
        Crawler myCrawler = new Crawler();

      
        if (args.Length >= 1)
            startUrl = args[0];


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

        Console.WriteLine("开始爬行了 ....");
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



            Console.WriteLine("爬行" + current + "页面!");
            string html = DownLoad(current);



            urls[current] = true;
            count++;
            if(judgehtml(current)||judgehtm(current)||judgejsp(current)||judgeaspx(current)||judgephp(current))
            Parse(html);
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

        string strRef = @"(href|HREF)\s*=\s*[""'][~""'#>]+[""']";
        MatchCollection matches = new Regex(strRef).Matches(html);


        foreach (Match match in matches)

        {

            strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ' ', '>');
            strRef = startUrl + strRef;

            if (strRef.Length == 0) continue;


            if (urls[strRef] == null) urls[strRef] = false;

        }
    }
}

