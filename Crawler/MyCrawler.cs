using CsQuery;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Crawler
{
    public class MyCrawler 
    {
        public List<Uri> Crawl(Uri uri)
        {
            using (HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) })
            {
                IEnumerable<Uri> preFiltered = new List<Uri>();
                var result = new List<Uri>() { uri };
                try
                {
                    string html = client.GetStringAsync(uri).Result;
                    preFiltered = CQ.Create(html)["a"].SafeSelect(i => new Uri(i.Attributes["href"]));
                }
                catch { }

                var filter = new UriFilter(uri);
                var filtered = filter.Filter(preFiltered);
                result.AddRange(filtered);
                foreach (var item in filtered)
                {
                    result.AddRange(Crawl(item));
                }
                return result;
            }
        }
    }
}
