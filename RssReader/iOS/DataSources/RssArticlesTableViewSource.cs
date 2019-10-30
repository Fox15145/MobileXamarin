using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using RssReader.Models;
using UIKit;

namespace RssReader.iOS.DataSources
{
    public class RssArticlesTableViewSource : UITableViewSource
    {
        private readonly List<RssArticle> data;

        public RssArticlesTableViewSource(List<RssArticle> data)
        {
            this.data = data;
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return new UITableViewRowAction[]
            {
             UITableViewRowAction.Create(UITableViewRowActionStyle.Default,  "Browse", (_, selectedIndexPath) =>
             {
                 var rssArticle = data[selectedIndexPath.Row];
                 UIApplication.SharedApplication.OpenUrl(new NSUrl(rssArticle.Link));
             })
            };
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = tableView.DequeueReusableCell("rssarticlecell", indexPath);

            cell.TextLabel.Text = data[indexPath.Row].Title;
            //cell.DetailTextLabel.Text = data[indexPath.Row].Link;
            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section) => this.data.Count();
    }
}
