using RssReader.Utils;

namespace RssReader.Services
{
    public static class RssSourceService
    {
        public static bool Add(string title, string url, Bdd bdd)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(url))
            {
                var rssSource = new RssReader.Models.RssSource
                {
                    Title = title,
                    Url = url
                };

                try
                {
                    bdd.Save(rssSource);
                }
                catch
                {
                    return false;
                }


                return true;
            }
            return false;
        }
    }
}
