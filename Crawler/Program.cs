using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите URL");
            //var url = Console.ReadLine();
            var url = "http://google.com";

            MyCrawler craw = new MyCrawler();
            SiteMapCrawler smCraw = new SiteMapCrawler();
            var crawResults = craw.Crawl(new Uri(url));
            var siteMresults = smCraw.GetSiteMapUrls(new Uri(url.TrimEnd('/')+"/sitemap.xml"));

           

           
        }

        

        
    }
}
