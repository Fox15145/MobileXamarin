using Foundation;
using RssReader.iOS.Utils;
using System;
using UIKit;
using System.Collections.Generic;
using RssReader.Models;
using System.Linq;

namespace RssReader.iOS
{
    public partial class HomeViewController : 
    UIViewController, 
    IUITableViewDataSource, IUITableViewDelegate
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            RssSourceTableView.DataSource = this;
        }
        List<RssSource> _rssItems = null;
        List<RssSource> rssItems
        {
            get
            {
                if (_rssItems == null)
                    _rssItems = BddHelper.Instance.GetAll().ToList();
                return _rssItems;
            }
        }

        public HomeViewController(IntPtr handle) : base(handle)
        {
        }

        private void RefreshItems()
        {
            _rssItems = BddHelper.Instance.GetAll().ToList();
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("rsssourcecell", indexPath);

            cell.TextLabel.Text = rssItems[indexPath.Row].Title;
            cell.DetailTextLabel.Text = rssItems[indexPath.Row].Url;
            return cell;
        }

        /// <summary>
        /// Compte les éléments
        /// </summary>
        /// <returns>The in section.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="section">Section.</param>
        public nint RowsInSection(UITableView tableView, nint section)
        {
            return rssItems.Count();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.DestinationViewController is AddRssSourceViewController)
            {
                var resourceAdded = (segue.DestinationViewController as AddRssSourceViewController);
                resourceAdded.OnSuccess += () =>
                {
                    RefreshItems();
                    RssSourceTableView.ReloadData();
                };
            }
            else
            if (segue.DestinationViewController is RssArticlesViewController)
            {
                var resourceAdded = (segue.DestinationViewController as RssArticlesViewController);

                var SelectedIndexRow = RssSourceTableView.IndexPathForSelectedRow;
                var selectRssSource = rssItems.ElementAt(SelectedIndexRow.Row);
                resourceAdded.Id = selectRssSource.Id;
                 //= BddHelper.Instance.GetById(resourceAdded.Id);
            }
            base.PrepareForSegue(segue, sender);
        }
        [Export("tableView:commitEditingStyle:forRowAtIndexPath:")]
        public void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {

            if (editingStyle == UITableViewCellEditingStyle.Delete)
            {
                var elt = rssItems[indexPath.Row];

                BddHelper.Instance.Delete(elt.Id);
                _rssItems = BddHelper.Instance.GetAll().ToList();
                tableView.ReloadData();
            }
        }
    }
}