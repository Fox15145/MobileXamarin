using System;
namespace RssReader.Models
{
    public class RssArticle
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
