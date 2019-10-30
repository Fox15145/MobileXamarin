using System;
using System.Collections.Generic;
using RssReader.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace RssReader.Utils
{
    public static class RssApi
    {
        public static async Task<List<RssArticle>> GetArticles(string url)
        {

            using (var HttpClient = new HttpClient())
            {
                var response = await HttpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                // Parser XML
                var rssArticles = XDocument
                    .Parse(content)
                        .Descendants("item")
                    .Select(item => new RssArticle
                    {
                        Title = item.Element("title").Value,
                        Description = item.Element("description").Value,
                        Link = item.Element("link").Value
                    }
                        ).ToList();

                // exemple de linq
                var rssArticles2 = from document in XDocument.Parse(content).Elements()
                                   from item in document.Descendants("item")
                                   select new RssArticle
                                   {
                                       Title = item.Element("title").Value,
                                       Description = item.Element("description").Value,
                                       Link = item.Element("link").Value
                                   };
                        

                return rssArticles;
            }

        }
    }
}
