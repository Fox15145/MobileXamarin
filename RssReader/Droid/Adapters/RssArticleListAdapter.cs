using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using RssReader.Models;

namespace RssReader.Droid.Adapters
{
    public class RssArticleListAdapter : BaseAdapter<RssArticle>
    {
        private readonly Activity context;
        private readonly List<RssArticle> data;

        public RssArticleListAdapter(Activity context, List<RssArticle> data)
        {
            this.context = context;
            this.data = data;
        }

        public override RssArticle this[int position] => data[position];

        public override int Count => data.Count();

        public override long GetItemId(int position) => -1;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var elt = data[position];

            // pour le recyclage : "convertView ??" et le "false"
            var view = convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);

            var textview_Title = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            textview_Title.Text = elt.Title;

            return view;
        }
    }
}
