using System;
using System.IO;
using RssReader.Utils;

namespace RssReader.Droid.Helpers
{
    public class BddHelper
    {
        public BddHelper()
        {
        }

        private static Bdd _instance;

        public static Bdd Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Bdd(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "rssreader.db"));
                return _instance;
            }
        }

    }
}
