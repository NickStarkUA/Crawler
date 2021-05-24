using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace Crawler
{
    public class SiteMapCrawler 
    {
        List<Uri> result = new List<Uri>();
        public List<Uri> GetSiteMapUrls(Uri url)
        {
            Uri baseurl = url;

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                try
                {
                    string reply = wc.DownloadString(baseurl);

                    XmlDocument urldoc = new XmlDocument();
                    urldoc.LoadXml(reply);

                    XmlNodeList xnList = urldoc.GetElementsByTagName("url");
                    XmlNodeList sitemapList = urldoc.GetElementsByTagName("sitemap");

                    foreach (XmlNode node in xnList)
                    {
                        result.Add(new Uri(node["loc"].InnerText));
                    }
                    foreach (XmlNode node in sitemapList)
                    {
                        var siteMapUrls = GetSiteMapUrls(new Uri(node["loc"].InnerText));
                        foreach (var item in siteMapUrls)
                        {
                            result.AddRange(GetSiteMapUrls(item));
                        }
                    }
                }
                catch { }
                    
            }
            return result;
        }

        

    }
}
