using Foundation;
using RssReader.iOS.DataSources;
using RssReader.iOS.Utils;
using RssReader.Models;
using RssReader.Utils;
using System;
using UIKit;

namespace RssReader.iOS
{
    public partial class RssArticlesViewController : UIViewController
    {
        // 1 - Création des propriétés pour recevoir les paramètres.
        // segue.DestintionController is RssArticlesViewController
        public long Id;

        public RssArticlesViewController(IntPtr handle) : base(handle)
        {

        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            RssSource rssSource = BddHelper.Instance.GetById(Id);

            loader.StartAnimating();

            var rssArticle = await RssApi.GetArticles(rssSource.Url);

            loader.StopAnimating();

            loader.Hidden = true;

            RssArticlesTableViewSource rssArticlesTableViewSource = new RssArticlesTableViewSource(rssArticle);
            RssArticlesTableView.Source = rssArticlesTableViewSource;

            this.Title = rssSource.Title;
        }
    }
}