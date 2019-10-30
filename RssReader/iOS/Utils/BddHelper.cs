using System;
using System.IO;
using RssReader.Utils;

namespace RssReader.iOS.Utils
{
    public class BddHelper
    {
        private static Bdd instance;

        public static Bdd Instance
        {
            get
            {
                if (instance == null)
                    instance = new Bdd(GetDbFile());

                return instance;
            }
        }

        private static string GetDbFile()
        {
            var appPath = Environment
                .GetFolderPath(Environment.SpecialFolder.Personal);

            var libPath = Path.Combine(appPath, "..", "Library", "Database");

            if (!Directory.Exists(libPath))
            {
                Directory.CreateDirectory(libPath);
            }

            return Path.Combine(libPath, "rssreader.db");
        }

        public BddHelper()
        {

        }
    }
}
