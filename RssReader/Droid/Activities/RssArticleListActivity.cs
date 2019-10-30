using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RssReader.Droid.Adapters;
using RssReader.Droid.Helpers;
using RssReader.Models;
using RssReader.Services;
using RssReader.Utils;

namespace RssReader.Droid.Activities
{
    [Activity(Label = "HomeActivity")]
    public class RssArticleListActivity : AppCompatActivity
    {
        TextView RssArticles_textView;
        ListView RssArticles_listView;
        ProgressBar RssArticles_ProgressBar;

        RssArticleListAdapter RssArticlesAdapter;
        SwipeRefreshLayout articles_swipeRefreshLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RssArticleList);

            RssArticles_textView = FindViewById<TextView>(Resource.Id.RssArticles_textView);
            RssArticles_listView = FindViewById<ListView>(Resource.Id.RssArticles_Listview);
            RssArticles_ProgressBar = FindViewById<ProgressBar>(Resource.Id.rssarticle_progressbar);
            articles_swipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.articles_swipeRefreshLayout);


            long rssSourceId = this.Intent.GetLongExtra(HomeActivity.C_ARTICLE_URL, -1);
            RssSource rssSource = BddHelper.Instance.GetById(rssSourceId);

            RssArticles_ProgressBar.Visibility = Android.Views.ViewStates.Visible;
            string url = rssSource.Url;

            RssArticles_textView.Text = rssSource.Title; 
            RefresDataListView(url);

            articles_swipeRefreshLayout.Refresh += async (sender, e) =>  { 
            //await load(url);
                articles_swipeRefreshLayout.Refreshing = false; 
                };

            RegisterForContextMenu(RssArticles_listView);
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v is ListView)
            {
                menu.Add(0, 0, 0, "Browse");
            }
            base.OnCreateContextMenu(menu, v, menuInfo);
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                var index = ((AdapterView.AdapterContextMenuInfo)item.MenuInfo).Position;
                var SelectedRssArticle = RssArticlesAdapter[index];

                var intent = new Intent(Intent.ActionView);

                intent.SetData(Android.Net.Uri.Parse(SelectedRssArticle.Link));
               

                StartActivity(intent);

                return true;
            }
            return base.OnContextItemSelected(item);
        }

        protected async void RefresDataListView(string url)
        {

            var myList = await RssApi.GetArticles(url);

            RssArticles_ProgressBar.Visibility = Android.Views.ViewStates.Gone;

            if (RssArticles_listView.Adapter == null)
            {
                RssArticlesAdapter = new RssArticleListAdapter(this, myList);
                RssArticles_listView.Adapter = RssArticlesAdapter;
            }
        }
    }
}
